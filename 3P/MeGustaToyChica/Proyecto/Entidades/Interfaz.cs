using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("interfaces")]
[Index("Id", IsUnique = true)]
public partial class Interfaz
{
	[Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_nvl_acc_interfaz")]
    public long IdNvlAccInterfaz { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [ForeignKey("IdNvlAccInterfaz")]
    [InverseProperty("Interfaces")]
    public virtual NvlAccInterfaz IdNvlAccInterfazNavigation { get; set; } = null!;
}
