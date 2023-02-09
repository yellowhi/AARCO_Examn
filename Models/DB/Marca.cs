using System;
using System.Collections.Generic;

namespace AARCO_Examn.Models.DB;

public partial class Marca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Submarca> Submarcas { get; } = new List<Submarca>();
}
