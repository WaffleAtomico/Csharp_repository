using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("tps_usuarios")]
public partial class TpoUsuario
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTpoUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [InverseProperty("IdTpoUsuarioNavigation")]
    public virtual ICollection<NvlAccInterfaz> NvlAccInterfaces { get; set; } = new List<NvlAccInterfaz>();
}
