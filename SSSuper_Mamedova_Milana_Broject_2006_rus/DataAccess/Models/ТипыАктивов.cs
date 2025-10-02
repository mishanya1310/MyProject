using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ТипыАктивов
{
    public int IdТипаАктива { get; set; }

    public string НаименованиеТипа { get; set; } = null!;

    public string КатегорияТипа { get; set; } = null!;

    public virtual ICollection<Активы> Активыs { get; set; } = new List<Активы>();
}
