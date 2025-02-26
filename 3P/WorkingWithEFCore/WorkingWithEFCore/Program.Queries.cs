//linq cosas para los matematicos, es infeciente
//linq es dificil de leer
//se debe de desmemebrar para saber las partes de una lambda

using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;

partial class Program
{
    static void QueryCategories()
    {
        using(Northwind db = new())
        {
            Sectiontitle($"Categories and how many products they have");
            //hay que desfragmentar la query

            //Select all categories -> SELECT * FROM CATEGORIES
            //Products that beloong to each category == JOIN
            //Producs COUNT
            //All queries must be a Iqueryable object
            IQueryable<Category> categories = db.Categories //acceso a un dbSet
            
            .Include(category => category.Products); //if we comment this part, it works too, but inneficient
            
            //esto trae con todos los objetos de las categories
            //se puede hacer el count de una lista
            // db.ChangeTracker.LazyLoadingEnabled = false; //Unable lazy loading
            if((categories is null) || !categories.Any()) //any determina si la secuencia contiene todo vacio
            {
                Fail("No categories found");
                return;
            }//use the data

            foreach (var category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products");
            }
            //
        } //close the db connection
    }

    static void FilterIncludes()
    {
        using(Northwind db = new())
        {
            Sectiontitle($"Products with a minimun of stock.");
            //SELECT FROM PRODCUTS WHERE

            string input;
            int stock;

            do
            {
                Write("Enter a minimum for unit in stock");
                input = ReadLine();
            }while(!int.TryParse(input, out stock));

            IQueryable<Category> categories = db.Categories?
            .Include( //dentro del join se agrega la tabla de products
                c => c.Products //hasta aqui llega la primera lambda
                .Where(
                    p => p.Stock >stock //se necesita la 2da ya que Where pide hacer una lambda
                    ) 
                );
            
            foreach (var category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products Wwith a minimum of  {stock} unit in stock");
                foreach (var product in category.Products)
                {
                    WriteLine($"{product.ProductName} has {product.Stock} unit in stock");
                }
            }
            
            //
        } //close the db connection
    }

    
    static void QueryProducts()
    {
        using(Northwind db = new())
        {
            Sectiontitle($"Products that cost more than price, and ordered by descending");
            //SELECT FROM PRODCUTS WHERE

            string input;
            decimal price;

            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            }while(!decimal.TryParse(input, out price));

            IQueryable<Product>? products = db.Products?
            .Where(p => p.Cost >= price)
            .OrderByDescending(product => product.Cost);
            
            Info($"ToQeuryString {products.ToQueryString()}");

            //logling, meter toda la info de consultas y llamadas a archivos

            if((products is null) || !products.Any()) //any determina si la secuencia contiene todo vacio
            {
                Fail("No products found");
                return;
            }//use the data

            foreach (var product in products)
            {
                WriteLine($"{product.ProductId}, {product.ProductName} cost {product.Cost: #,##0.00} and has {product.Stock} unit in stock");
            }

        } //close the db connection
    }


    static void QueryingWithLike()
    {
        using(Northwind db = new())
        {
            Sectiontitle($"Pattern Matching with LIKE.");
            //SELECT FROM PRODCUTS WHERE

            string  input = ReadLine();
            if(string.IsNullOrWhiteSpace(input))
            {
                Fail("You did not enter a prodyct name");
                return;
            }

            IQueryable<Product>? products = db.Products?
            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
            
            Info($"ToQeuryString {products.ToQueryString()}");

            //logling, meter toda la info de consultas y llamadas a archivos

            if((products is null) || !products.Any()) //any determina si la secuencia contiene todo vacio
            {
                Fail("No products found");
                return;
            }//use the data

            foreach (var product in products)
            {
                WriteLine($"{product.ProductName}, {product.Stock} unit in stock. Discontinued? {product.Discontinued}");
            }

        } //close the db connection
    }


    static void GetRandomProduct()
    {
        using(Northwind db = new())
        {
            Sectiontitle($"Get a Rndom product");
            
            int? rowCount = db.Products.Count();
            if(rowCount is null)
            {
                Fail("Product table is Empty");
                return;
            }
            Product? p = db.Products?
            .FirstOrDefault(
                p => p.ProductId == 
                (int)(EF.Functions.Random()*rowCount)
                );
            //Si hay id double se estan mmdo, puro int

            if(p is null)
            {
                Fail("Product not found");
                return;
            }
            WriteLine($"Random product: {p.ProductId} {p.ProductName}");

        } //close the db connection
    }

    


    /*
        El ususario y el tester es el peor enemigo del programador
        se puede obtener como genera la query
    */
}