using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Транзакции
{
    public int IdТранзакции { get; set; }

    public int IdПользователя { get; set; }

    public int IdАктива { get; set; }

    public string ТипТранзакции { get; set; } = null!;

    public decimal Сумма { get; set; }

    public DateTime? ДатаТранзакции { get; set; }

    public virtual Активы IdАктиваNavigation { get; set; } = null!;

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;
}
