using System;
using System.Collections.Generic;

namespace AARCO_Examn.Models.DB;

public partial class Submarca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdMarca { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }

    public virtual ICollection<Modelo> Modelos { get; } = new List<Modelo>();
}
