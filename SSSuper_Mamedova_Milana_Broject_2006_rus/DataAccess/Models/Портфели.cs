using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Портфели
{
    public int IdПортфеля { get; set; }

    public int IdПользователя { get; set; }

    public string НаименованиеПортфеля { get; set; } = null!;

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual ICollection<СоставПортфеля> СоставПортфеляs { get; set; } = new List<СоставПортфеля>();
}
