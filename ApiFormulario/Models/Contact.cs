using System;
using System.Collections.Generic;

namespace ApiFormulario.Models;

public partial class Contact
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Comentario { get; set; } = null!;
}
