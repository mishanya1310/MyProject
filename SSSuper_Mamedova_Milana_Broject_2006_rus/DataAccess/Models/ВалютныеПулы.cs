using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ВалютныеПулы
{
    public int IdПары { get; set; }

    public string НаименованиеПары { get; set; } = null!;

    public int IdБазовогоАктива { get; set; }

    public int IdКотируемогоАктива { get; set; }

    public int IdДецентрализованнойБиржи { get; set; }

    public decimal ОбщаяЛиквидность { get; set; }

    public decimal ОбъемТоргов24ч { get; set; }

    public decimal КомиссияПула { get; set; }

    public bool Активен { get; set; }

    public virtual Активы IdБазовогоАктиваNavigation { get; set; } = null!;

    public virtual Активы IdКотируемогоАктиваNavigation { get; set; } = null!;
}
