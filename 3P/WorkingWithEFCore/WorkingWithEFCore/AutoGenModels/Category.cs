using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen;

//Humanizer, es una libreria que automatiza la singularidad de cada tabla de la base de datos
//ayuda a mapear de manera unitaria la bd
//crea de manera mas natural, como si la hiciera un ser humano

//se hacen las clases parciales
//las clases parciaales lo que tienen es que a la hora de compilar van a ser parte la de clase originar, digamos
//de este va a ser parte de la clase original que se llama Category
//Es como si se dividiera el archivo en varios archivos, pero terminan en el mismo

[Index("CategoryName", Name = "CategoryName")] //unnecesary 
public partial class Category
{
    [Key]
    public long CategoryId { get; set; }

    [Column(TypeName = "nvarchar (15)")]
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Picture { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
