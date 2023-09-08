using System;
using System.Collections.Generic;

namespace Confecciones_Condor_1.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public int? AreaId { get; set; }

    public virtual Area? Area { get; set; }
}
