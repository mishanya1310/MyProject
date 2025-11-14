using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public int IdПрофиляРиска { get; set; }

    public string ПредпочитаемыеКатегории { get; set; } = null!;

    public bool Активен { get; set; }

    public virtual ПрофилиРиска IdПрофиляРискаNavigation { get; set; } = null!;

    public virtual ICollection<Портфели> Портфелиs { get; set; } = new List<Портфели>();

    public virtual ICollection<Рекомендации> Рекомендацииs { get; set; } = new List<Рекомендации>();

    public virtual ICollection<Транзакции> Транзакцииs { get; set; } = new List<Транзакции>();
}
