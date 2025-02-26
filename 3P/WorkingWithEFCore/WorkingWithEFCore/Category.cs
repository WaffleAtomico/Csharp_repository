using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithEFCore;

public class Category
{
    //aqui se mapean todos los campos
    //data annotations, ayudan a hacer validaciones en el campo en el que estamos tratando de mapear
    //estas van arriba del campo al que queremos afectar, puede tener multiples anotaciones un campo
    //una de las ventajas de usar entity framework, es que no se debe de mapear todo, no se necesita mapear 
    //si no se va a usar en el momento, no debe de ser exacta la imagen si se usa en el backend, se puede 
    // cambiar todo
    public int CategoryId {get; set;}
    public string? CategoryName {get; set;}

    [Column(TypeName = "ntext")]
    public string? Description {get; set;}

    //navigations property's estas ayudan para las foreight keys
    //siempre deben de ser publica y virtual
    //When a Join is called related rows

    //cuando se crea una Navigation property, se debe de inicializar en el constructor
    //cuando se inicie en el constructor se debe de dejar como nula hasta que se cree otra nueva?
    public  virtual ICollection<Product> Products {get;set;}
    //
    public Category(){
        //We need a way to add products to a category
        //initialize the navigation property to an empty collection

        //initialize ICollection of Products
        //se usa una HashSet ya que no permite duplicados

        Products = new HashSet<Product>(); //<- navigation property 
        //no hay collection perfecta, pero depende del proyecto la que se use
        //las columnas que no existen no las lee, son nullas las querys que no hay nd
    }
}
