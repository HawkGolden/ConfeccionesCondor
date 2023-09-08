using System;
using System.Collections.Generic;

namespace Confecciones_Condor_1.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string NombreArea { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
