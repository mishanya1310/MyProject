using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class СоставПортфеля
{
    public int IdЗаписиСоставаПортфеля { get; set; }

    public int IdПортфеля { get; set; }

    public int IdАктива { get; set; }

    public decimal Количество { get; set; }

    public virtual Активы IdАктиваNavigation { get; set; } = null!;

    public virtual Портфели IdПортфеляNavigation { get; set; } = null!;
}
