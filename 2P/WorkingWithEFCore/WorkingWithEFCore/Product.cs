// StringLenght, Required, ContentType
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithEFCore;
//aqui se mapean cada uno de los campos a las tablas, pero hace falta mapaear las tablas al manejo general 
public class Product
{ //se debe de declarar de tal manera que solo solicite el que se pide
    public int ProductId{get;set;} //PK

    [Required]
    [StringLength(40)] //<- estas afectan al de abajo v 
    public string? ProductName{get;set;} = null!;

    [StringLength(20)]
    [Column("QuantityPerUnit")]
    public string? Quantity {get;set;}

    [Column("UnitPrice", TypeName = "money")] //    [Column("UnitPrice", TypeName = "numeric")]
    public decimal? Cost {get;set;} //su alias es cost, pero se llama UnitPrice

    [Column("UnitsInStock")]
    public short Stock {get;set;}

    public bool Discontinued {get;set;}


    //RelationShips on the FK v

    //navigations properties
    public int CategoryId {get;set;}
    public virtual Category Category {get;set;} = null!; //esta es una FK
    //no es necesario volver a pedir o guardar esto mismo
    //se instancia catogory y ICollection, solo que esta en category
     // implicitamente si esta guardando una collection

     //aqui solo se ha terminado de mapear UNA tabla


     //se van a crear unas cosas llamadas divisets
     //como se puede hacer la relacion de la de product,
     // se puede hacia la de Category, ya estan "Unidas"
}