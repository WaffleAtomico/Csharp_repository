using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("nvl_acc_interfaces")]
[Index("Id", IsUnique = true)]
public partial class NvlAccInterfaz
{
	[Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("nvl_acceso")]
    public long NvlAcceso { get; set; }

    [Column("id_tpo_usuario")]
    public long IdTpoUsuario { get; set; }

    [ForeignKey("IdTpoUsuario")]
    [InverseProperty("NvlAccInterfaces")]
    public virtual TpoUsuario IdTpoUsuarioNavigation { get; set; } = null!;

	[InverseProperty("IdNvlAccInterfazNavigation")]
    public virtual ICollection<Interfaz> Interfaces { get; set; } = new List<Interfaz>();
}
