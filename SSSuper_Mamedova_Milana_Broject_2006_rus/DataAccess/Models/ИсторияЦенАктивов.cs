using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ИсторияЦенАктивов
{
    public int IdЗаписи { get; set; }

    public int IdАктива { get; set; }

    public decimal Цена { get; set; }

    public DateTime ДатаВремяЗаписи { get; set; }

    public decimal? РыночнаяКапитализация { get; set; }

    public decimal? ОбъемТоргов24ч { get; set; }

    public virtual Активы IdАктиваNavigation { get; set; } = null!;
}
