using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WorkingWithEFCore.AutoGen;


namespace Northwind.Web.Pages
{
    public class backindex
    {
        public void onGet()
        {
            // Model.DayName = DateTime.Now.ToString("dddd");
            //Model mapea todo el codigo para poderlo usar dentro del html
        }

        static int DELETE(long CategoryId)
        {
            using (WorkingWithEFCore.AutoGen.Northwind db = new())
            {
                IQueryable<Category>? categories = db.Categories?.Where
                (
                c => c.CategoryId.Equals(CategoryId)
                );
                if (categories is null || !categories.Any())
                {
                    WriteLine("No Categories afeccted");
                    return 0;
                }
                else
                {
                    if (db.Categories is null) return 0;
                    db.Categories.RemoveRange(categories); //remove for 1
                }
                int afeccted = db.SaveChanges();
                return afeccted;
            }
        }

        public bool ADD(string categoryName, string description)
        {
            try
            {
                using (WorkingWithEFCore.AutoGen.Northwind db = new())
                {
                    if (db.Categories is null) return false;
                    Category c = new()
                    {
                        CategoryId = NextId(),
                        CategoryName = categoryName,
                        Description = description,
                        Picture = null
                    };
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry
                    <Category> entity = db.Categories.Add(c);
                    int affected = db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Variables: {categoryName} {description}");
                // Console.WriteLine($"DbUpdateException: {ex.Message}");
                return false;
            }
        }

        public long NextId()
        { //se puede mejorar para evitar el error de que si no hay registro alguno
            using (WorkingWithEFCore.AutoGen.Northwind db = new())
            {
                long maxCategoryId = db.Categories.Max(c => c.CategoryId) + 1;
                //Model.CategoryIdMax = maxCategoryId;
                return maxCategoryId;
            }
        }

        public bool OnPost(){
            return true;
        }
    }
}