using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{
    static void ListProducts(int []? productsToHiglight = null)
    {
        using(Northwind db = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "ProductName", "Cost", "Stock", "Disc");
            foreach (var product in db.Products)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((productsToHiglight is not null) && productsToHiglight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Red;
                }
                WriteLine("| {0:0000} | {1,-35} | {2,8:$##0.00} | {3,5} | {4}",
                product.ProductId, product.ProductName, product.Stock, product.Discontinued);
                ForegroundColor = backgroundColor;
            }
        }
    }

    static (int affected, int ProductId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return(0,0);
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };
            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State} ProductId {p.ProductId}");
            int affected = db.SaveChanges();
            WriteLine($"State {entity.State} ProductId {p.ProductId}");
            return (affected, p.ProductId);
        }
    }

    static(int affected, int prodctId) UpdateProductPrice(string productNameStarWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
        
             Product updateProduct =
            db.Products.First
            (
                p => p.ProductName.StartsWith(productNameStarWith)
            );
            updateProduct.Cost = amount;
            int affected = db.SaveChanges();
            return(affected, updateProduct.ProductId);
        }
       
    }

    static int DeleteProducts(string productnameStartWith)
    {
        using(Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where
            (
                p => p.ProductName.StartsWith(productnameStartWith)
            );
            if(products is null || !products.Any())
            {
                WriteLine("No products afeccted");
                return 0;
            }
            else
            {
                if(db.Products is null) return 0;
                db.Products.RemoveRange(products); //remove for 1
            }
            int afeccted = db.SaveChanges();
            return afeccted;
        }
    }

    static(int affected, int[]? prodctId) UpdateProductPriceBetter(string productNameStarWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,null);
        
             IQueryable<Product>? products =
            db.Products.Where
            (
                p => p.ProductName.StartsWith(productNameStarWith)
            );
            int affected = products.ExecuteUpdate(u => u.SetProperty
            (
                p => p.Cost, //propert selector
                p => p.Cost + amount //value to edit
            ));
            int[] productsIds = products.Select(p => p.ProductId).ToArray();
            // afeccted = db.SaveChanges();
            return(affected, productsIds);
        }  
    }

    //better delete

    static int DeleteProductsBetter(string productnameStartWith)
    {
        using(Northwind db = new())
        {
            int afeccted = 0;
            IQueryable<Product>? products = db.Products?.Where
            (
                p => p.ProductName.StartsWith(productnameStartWith)
            );
            if(products is null || !products.Any())
            {
                WriteLine("No products afeccted");
                return 0;
            }
            else
            {
                afeccted = products.ExecuteDelete();
            }
            return afeccted;
        }
    }


}