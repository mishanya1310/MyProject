using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Рекомендации
{
    public int IdРекомендации { get; set; }

    public int IdПользователя { get; set; }

    public int IdАктива { get; set; }

    public decimal ОценкаРекомендации { get; set; }

    public string Обоснование { get; set; } = null!;

    public DateTime? ДатаРекомендации { get; set; }

    public virtual Активы IdАктиваNavigation { get; set; } = null!;

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;
}
