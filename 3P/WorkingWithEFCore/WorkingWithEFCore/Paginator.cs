using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{

    //paginados de 1 en 1
    //5
    //10
    //25
    //50

    //depende del numero de sesgos es el de paginas que hay

    //desde la 1 no se puede mover a la izquierda
    //desde la 10 no se puede a la derecha
    //el numero de los 
    static void ListProductsPaginator(int []? productsToHiglight = null, int? startpag=null, int? endpag=null)
    {
        using(Northwind db = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-4} | {1,-35} | {2,8} | {3,5} | {4}",
            "Pid", "pName", "pStock", "pDisc", "Category");

            foreach (var product in db.Products)
            {
                
                IQueryable<Category> categories = db.Categories?.Where(c =>c.CategoryId == product.CategoryId);

                ConsoleColor backgroundColor = ForegroundColor;
                if((productsToHiglight is not null) && productsToHiglight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Red;
                }

                if(product.ProductId >= startpag && product.ProductId <= endpag)
                {
                    foreach (var category in categories)
                    {
                    WriteLine("| {0:0000} | {1,-35} | {2,8:$##0.00} | {3,5} | {4}",
                        product.ProductId, product.ProductName, product.Stock, product.Discontinued, category.CategoryName);
                        ForegroundColor = backgroundColor;
                    }
                } 
            }
        }
    }

}