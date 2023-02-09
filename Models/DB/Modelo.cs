using System;
using System.Collections.Generic;

namespace AARCO_Examn.Models.DB;

public partial class Modelo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdSubmarca { get; set; }

    public virtual ICollection<Descripcion> Descripcions { get; } = new List<Descripcion>();

    public virtual Submarca? IdSubmarcaNavigation { get; set; }
}
