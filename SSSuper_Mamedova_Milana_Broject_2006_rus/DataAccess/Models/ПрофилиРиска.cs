using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ПрофилиРиска
{
    public int IdПрофиляРиска { get; set; }

    public string НаименованиеПрофиля { get; set; } = null!;

    public decimal МинПриемлемаВолатильность { get; set; }

    public decimal МаксПриемлемаВолатильность { get; set; }

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();
}
