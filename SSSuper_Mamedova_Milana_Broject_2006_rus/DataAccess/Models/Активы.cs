using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Активы
{
    public int IdАктива { get; set; }

    public string НаименованиеАктива { get; set; } = null!;

    public string СимволАктива { get; set; } = null!;

    public int IdТипаАктива { get; set; }

    public decimal ТекущаяЦена { get; set; }

    public decimal ИндексВолатильности { get; set; }

    public decimal ЭкспертнаяОценкаПерспективы { get; set; }

    public virtual ТипыАктивов IdТипаАктиваNavigation { get; set; } = null!;

    public virtual ICollection<ВалютныеПулы> ВалютныеПулыIdБазовогоАктиваNavigations { get; set; } = new List<ВалютныеПулы>();

    public virtual ICollection<ВалютныеПулы> ВалютныеПулыIdКотируемогоАктиваNavigations { get; set; } = new List<ВалютныеПулы>();

    public virtual ICollection<ИсторияЦенАктивов> ИсторияЦенАктивовs { get; set; } = new List<ИсторияЦенАктивов>();

    public virtual ICollection<ПротоколыСтейкинг> ПротоколыСтейкингIdАктиваВознагражденияNavigations { get; set; } = new List<ПротоколыСтейкинг>();

    public virtual ICollection<ПротоколыСтейкинг> ПротоколыСтейкингIdАктиваДляВкладаNavigations { get; set; } = new List<ПротоколыСтейкинг>();

    public virtual ICollection<Рекомендации> Рекомендацииs { get; set; } = new List<Рекомендации>();

    public virtual ICollection<СоставПортфеля> СоставПортфеляs { get; set; } = new List<СоставПортфеля>();

    public virtual ICollection<Транзакции> Транзакцииs { get; set; } = new List<Транзакции>();
}
