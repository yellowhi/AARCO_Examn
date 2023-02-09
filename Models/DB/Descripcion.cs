using System;
using System.Collections.Generic;

namespace AARCO_Examn.Models.DB;

public partial class Descripcion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdModelo { get; set; }

    public string? DescripcionId { get; set; }

    public virtual Modelo? IdModeloNavigation { get; set; }
}
