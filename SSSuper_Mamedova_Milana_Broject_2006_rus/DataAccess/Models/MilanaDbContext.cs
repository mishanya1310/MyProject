using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class MilanaDbContext : DbContext
{
    public MilanaDbContext()
    {
    }

    public MilanaDbContext(DbContextOptions<MilanaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Активы> Активыs { get; set; }

    public virtual DbSet<ВалютныеПулы> ВалютныеПулыs { get; set; }

    public virtual DbSet<ИсторияЦенАктивов> ИсторияЦенАктивовs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Портфели> Портфелиs { get; set; }

    public virtual DbSet<ПротоколыСтейкинг> ПротоколыСтейкингs { get; set; }

    public virtual DbSet<ПрофилиРиска> ПрофилиРискаs { get; set; }

    public virtual DbSet<Рекомендации> Рекомендацииs { get; set; }

    public virtual DbSet<СоставПортфеля> СоставПортфеляs { get; set; }

    public virtual DbSet<ТипыАктивов> ТипыАктивовs { get; set; }

    public virtual DbSet<Транзакции> Транзакцииs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Активы>(entity =>
        {
            entity.HasKey(e => e.IdАктива).HasName("PK__Активы__25E2337AD8F0D3AB");

            entity.ToTable("Активы");

            entity.Property(e => e.IdАктива).HasColumnName("id_Актива");
            entity.Property(e => e.IdТипаАктива).HasColumnName("id_ТипаАктива");
            entity.Property(e => e.ИндексВолатильности).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.НаименованиеАктива).HasMaxLength(255);
            entity.Property(e => e.СимволАктива).HasMaxLength(20);
            entity.Property(e => e.ТекущаяЦена).HasColumnType("decimal(20, 8)");
            entity.Property(e => e.ЭкспертнаяОценкаПерспективы).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.IdТипаАктиваNavigation).WithMany(p => p.Активыs)
                .HasForeignKey(d => d.IdТипаАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Активы_ТипыАктивов");
        });

        modelBuilder.Entity<ВалютныеПулы>(entity =>
        {
            entity.HasKey(e => e.IdПары).HasName("PK__Валютные__F3058DD304D5F0A3");

            entity.ToTable("ВалютныеПулы");

            entity.Property(e => e.IdПары).HasColumnName("id_Пары");
            entity.Property(e => e.IdБазовогоАктива).HasColumnName("id_БазовогоАктива");
            entity.Property(e => e.IdДецентрализованнойБиржи).HasColumnName("id_ДецентрализованнойБиржи");
            entity.Property(e => e.IdКотируемогоАктива).HasColumnName("id_КотируемогоАктива");
            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.КомиссияПула).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.НаименованиеПары).HasMaxLength(50);
            entity.Property(e => e.ОбщаяЛиквидность).HasColumnType("decimal(28, 8)");
            entity.Property(e => e.ОбъемТоргов24ч).HasColumnType("decimal(28, 8)");

            entity.HasOne(d => d.IdБазовогоАктиваNavigation).WithMany(p => p.ВалютныеПулыIdБазовогоАктиваNavigations)
                .HasForeignKey(d => d.IdБазовогоАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ВалютныеПулы_БазовыйАктив");

            entity.HasOne(d => d.IdКотируемогоАктиваNavigation).WithMany(p => p.ВалютныеПулыIdКотируемогоАктиваNavigations)
                .HasForeignKey(d => d.IdКотируемогоАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ВалютныеПулы_КотируемыйАктив");
        });

        modelBuilder.Entity<ИсторияЦенАктивов>(entity =>
        {
            entity.HasKey(e => e.IdЗаписи).HasName("PK__ИсторияЦ__568B27B7E0FFFB20");

            entity.ToTable("ИсторияЦенАктивов");

            entity.Property(e => e.IdЗаписи).HasColumnName("id_Записи");
            entity.Property(e => e.IdАктива).HasColumnName("id_Актива");
            entity.Property(e => e.ДатаВремяЗаписи).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ОбъемТоргов24ч).HasColumnType("decimal(28, 8)");
            entity.Property(e => e.РыночнаяКапитализация).HasColumnType("decimal(28, 8)");
            entity.Property(e => e.Цена).HasColumnType("decimal(20, 8)");

            entity.HasOne(d => d.IdАктиваNavigation).WithMany(p => p.ИсторияЦенАктивовs)
                .HasForeignKey(d => d.IdАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ИсторияЦенАктивов_Активы");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя).HasName("PK__Пользова__1E6A6F372A7F9ACB");

            entity.ToTable("Пользователи");

            entity.HasIndex(e => e.Логин, "UQ__Пользова__BC2217D396A0B0B1").IsUnique();

            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.IdПрофиляРиска).HasColumnName("id_ПрофиляРиска");
            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(255);

            entity.HasOne(d => d.IdПрофиляРискаNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.IdПрофиляРиска)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пользователи_ПрофилиРиска");
        });

        modelBuilder.Entity<Портфели>(entity =>
        {
            entity.HasKey(e => e.IdПортфеля).HasName("PK__Портфели__9335291F49017360");

            entity.ToTable("Портфели");

            entity.Property(e => e.IdПортфеля).HasColumnName("id_Портфеля");
            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.НаименованиеПортфеля).HasMaxLength(255);

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Портфелиs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Портфели_Пользователи");
        });

        modelBuilder.Entity<ПротоколыСтейкинг>(entity =>
        {
            entity.HasKey(e => e.IdПротокола).HasName("PK__Протокол__3CA11A201CCA4A52");

            entity.ToTable("ПротоколыСтейкинг");

            entity.Property(e => e.IdПротокола).HasColumnName("id_Протокола");
            entity.Property(e => e.IdАктиваВознаграждения).HasColumnName("id_АктиваВознаграждения");
            entity.Property(e => e.IdАктиваДляВклада).HasColumnName("id_АктиваДляВклада");
            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.ГодоваяПроцентнаяДоходность).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.НаименованиеПротокола).HasMaxLength(255);
            entity.Property(e => e.ТипПротокола).HasMaxLength(100);

            entity.HasOne(d => d.IdАктиваВознагражденияNavigation).WithMany(p => p.ПротоколыСтейкингIdАктиваВознагражденияNavigations)
                .HasForeignKey(d => d.IdАктиваВознаграждения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПротоколыСтейкинг_АктивВознаграждение");

            entity.HasOne(d => d.IdАктиваДляВкладаNavigation).WithMany(p => p.ПротоколыСтейкингIdАктиваДляВкладаNavigations)
                .HasForeignKey(d => d.IdАктиваДляВклада)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПротоколыСтейкинг_АктивВклад");
        });

        modelBuilder.Entity<ПрофилиРиска>(entity =>
        {
            entity.HasKey(e => e.IdПрофиляРиска).HasName("PK__ПрофилиР__4064DAA5E0105D10");

            entity.ToTable("ПрофилиРиска");

            entity.Property(e => e.IdПрофиляРиска).HasColumnName("id_ПрофиляРиска");
            entity.Property(e => e.МаксПриемлемаВолатильность).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.МинПриемлемаВолатильность).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.НаименованиеПрофиля).HasMaxLength(100);
        });

        modelBuilder.Entity<Рекомендации>(entity =>
        {
            entity.HasKey(e => e.IdРекомендации).HasName("PK__Рекоменд__E9AF96B46D6DDFD4");

            entity.ToTable("Рекомендации");

            entity.HasIndex(e => new { e.IdПользователя, e.IdАктива }, "UK_Пользователь_Актив").IsUnique();

            entity.Property(e => e.IdРекомендации).HasColumnName("id_Рекомендации");
            entity.Property(e => e.IdАктива).HasColumnName("id_Актива");
            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.ДатаРекомендации).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ОценкаРекомендации).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.IdАктиваNavigation).WithMany(p => p.Рекомендацииs)
                .HasForeignKey(d => d.IdАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Рекомендации_Активы");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Рекомендацииs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Рекомендации_Пользователи");
        });

        modelBuilder.Entity<СоставПортфеля>(entity =>
        {
            entity.HasKey(e => e.IdЗаписиСоставаПортфеля).HasName("PK__СоставПо__1CDE6B31078EAF76");

            entity.ToTable("СоставПортфеля");

            entity.HasIndex(e => new { e.IdПортфеля, e.IdАктива }, "UK_Портфель_Актив").IsUnique();

            entity.Property(e => e.IdЗаписиСоставаПортфеля).HasColumnName("id_ЗаписиСоставаПортфеля");
            entity.Property(e => e.IdАктива).HasColumnName("id_Актива");
            entity.Property(e => e.IdПортфеля).HasColumnName("id_Портфеля");
            entity.Property(e => e.Количество).HasColumnType("decimal(20, 8)");

            entity.HasOne(d => d.IdАктиваNavigation).WithMany(p => p.СоставПортфеляs)
                .HasForeignKey(d => d.IdАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СоставПортфеля_Активы");

            entity.HasOne(d => d.IdПортфеляNavigation).WithMany(p => p.СоставПортфеляs)
                .HasForeignKey(d => d.IdПортфеля)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_СоставПортфеля_Портфели");
        });

        modelBuilder.Entity<ТипыАктивов>(entity =>
        {
            entity.HasKey(e => e.IdТипаАктива).HasName("PK__ТипыАкти__DFF09A934F584580");

            entity.ToTable("ТипыАктивов");

            entity.Property(e => e.IdТипаАктива).HasColumnName("id_ТипаАктива");
            entity.Property(e => e.КатегорияТипа).HasMaxLength(100);
            entity.Property(e => e.НаименованиеТипа).HasMaxLength(100);
        });

        modelBuilder.Entity<Транзакции>(entity =>
        {
            entity.HasKey(e => e.IdТранзакции).HasName("PK__Транзакц__B0E995E00C92742E");

            entity.ToTable("Транзакции");

            entity.Property(e => e.IdТранзакции).HasColumnName("id_Транзакции");
            entity.Property(e => e.IdАктива).HasColumnName("id_Актива");
            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.ДатаТранзакции).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Сумма).HasColumnType("decimal(20, 8)");
            entity.Property(e => e.ТипТранзакции).HasMaxLength(10);

            entity.HasOne(d => d.IdАктиваNavigation).WithMany(p => p.Транзакцииs)
                .HasForeignKey(d => d.IdАктива)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Транзакции_Активы");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Транзакцииs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Транзакции_Пользователи");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
