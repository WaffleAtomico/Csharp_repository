using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore;

public class Northwind : DbContext
{
    //There propeties tell which tables are available
    public DbSet<Category>? Categories {get;set;} //DbSet tipo Category
    public DbSet<Product>? Products {get;set;} //? == nullable

    //There properties
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind4SQLite.db");
        string connection = $"Filename={path}";
        ConsoleColor backgroundColor =ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {path}");
        //use de DB motor
        optionsBuilder.UseSqlite(connection);
        ForegroundColor = ConsoleColor.White;

        //Lazy loading puede verse y utilizarse mejor si =
        //para verse mejor seria usar hilos
        //bases de datos mas grandes
        //querys mas puercotas -> querys -> Archivos de clase

        optionsBuilder.UseLazyLoadingProxies();

        //solo hasta que se llegaran a necesitar las cosas imprime el producto
        //Solo hasta que se necesitan las cosas carga en memoria los datos de las tablas


        /*---- use when you want to logging ----*/

        //optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging(); //asi sabe que va a agarrar todo lo que haya en la consola
        
        //acepta cualquier tipo de dato que pueda escribir en el
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        Hay que sobreescribir este metodo para configurar el 
        modelo que es descubierto a base de convenciones, hay 2 tipos,


        Va a poder ver que existen clases que existen agregadas via DBset

        Va hacer esto 
        Busca Category y dice C: "Ola soy category"
        OMC: Tienes algo que mapear? C:zy, un categoryID, un Cateogry Name, description
        
        */

        //Fluent API
        //limit Lenght of category Name

        // base.OnModelCreating(modelBuilder);
        //Tiene 3 partes
        //Fluent API:
            //Use of modelBuilder
            //Whos the entitiy that i want to use
            //Property to validate (Recibe lambdas)
            //Validate the shit out of that

        
        modelBuilder.Entity<Category>() //se escribe el campo que se quiere afectar, CategoryName 
        .Property(category => category.CategoryName) //infiere del tipo que se usa y por eso sabe el campo
        .IsRequired() //Not Null
        .HasMaxLength(15);

        //Add Fluent API for Cost on Product

        if(Database.ProviderName?.Contains("Sqlite") ?? false) //se pregunta antes 
        { //si si
            modelBuilder.Entity<Product>() //podemos el tipo, a quien quiero afectar? costo esta en producto
            .Property(product => product.Cost) //le decimos el tipo y campo vaya
            .HasConversion<double>();
            // .HasConversion<decimal>(); //convertimos el dipo que es, hay que dejarlo en Double
        }
    }
}


// dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --
//dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Employees --table Categories --table Customers --table Shippers --table Suppliers --table Orders --table Products --table 'Order Details' --table Territories --table EmployeeTerritories
/* 
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite
 --table Employees --table Categories --table Customers --table Shippers --table Suppliers --table Orders 
 --table Products --table 'Order Details' --table Territories --table EmployeeTerritories 
 --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGens --data-annotations --context Northwind



dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Employees --table Categories --table Customers --table Shippers --table Suppliers --table Orders --table Products --table 'Order Details' --table Territories --table EmployeeTerritories --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGens --data-annotations --context Northwind

dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Employees --table Categories --table Customers --table Shippers --table Suppliers --table Orders --table Products --table 'Order Details' --table Territories --table EmployeeTerritories --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGens --data-annotations --context Northwind

dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --table Employees --table Customers --table Suppliers --table Orders --table 'Order Details' --table Shippers --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context Northwind

dotnet ef dbcontext scaffold "Filename=Northwind4SQLite.db" Microsoft.EntityFrameworkCore.Sqlite --table Employees --table Categories --table Customers --table Shippers --table Suppliers --table Orders --table Products --table 'Order Details' --table Territories --table EmployeeTerritories --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGens --data-annotations --context Northwind


WorkingWithEFCore\WorkingWithEFCore\Northwind4SQLite.db
WorkingWithEFCore\WorkingWithEFCore\Northwind.db
*/

// <!-- Dotnet add package Microsoft.EntityFrameworkCore.Sqlite -->
// <!-- Dotnet add package Microsoft.EntityFrameworkCore.Design -->



/*
Scaffolding se debe de hacer update cada que se use, por si las dudas, ejecutando estos comandos



*/