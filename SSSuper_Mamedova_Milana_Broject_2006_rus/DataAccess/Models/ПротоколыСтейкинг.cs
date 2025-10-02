using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ПротоколыСтейкинг
{
    public int IdПротокола { get; set; }

    public string НаименованиеПротокола { get; set; } = null!;

    public string ТипПротокола { get; set; } = null!;

    public int IdАктиваДляВклада { get; set; }

    public int IdАктиваВознаграждения { get; set; }

    public decimal ГодоваяПроцентнаяДоходность { get; set; }

    public int УровеньРискаПротокола { get; set; }

    public string? ОписаниеПротокола { get; set; }

    public bool Активен { get; set; }

    public virtual Активы IdАктиваВознагражденияNavigation { get; set; } = null!;

    public virtual Активы IdАктиваДляВкладаNavigation { get; set; } = null!;
}
