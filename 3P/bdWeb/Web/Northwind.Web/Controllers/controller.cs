using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkingWithEFCore.AutoGen;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Northwind.Web.Controllers
{
    [Route("[controller]")]
    public class controller : Controller
    {
        private readonly ILogger<controller> _logger;
        // public readonly IActionResult<controller> Create;

        public controller(ILogger<controller> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            WriteLine("Entre a la view del index");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        // [ActionName("/Create")]
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            using (WorkingWithEFCore.AutoGen.Northwind db = new())
            {
                if (db.Categories is null) return NotFound();
                Category c = category;
                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Category> entity = db.Categories.Add(c);
                int affected = db.SaveChanges();
                return Ok();
            }
        }

        [ActionName("/Delete")]
        // [HttpDelete]
        public IActionResult Delete(int? id)
        {
            using (WorkingWithEFCore.AutoGen.Northwind db = new())
            {
                WriteLine("Delete");
                IQueryable<Category>? categories = db.Categories?.Where
                (
                c => c.CategoryId.Equals(id)
                );
                if (categories is null || !categories.Any())
                {
                    return Json(new { message = "Category created successfully" });
                }
                else
                {
                    if (db.Categories is null) return NotFound();
                    db.Categories.RemoveRange(categories); //remove for 1
                }
                int affected = db.SaveChanges();
                if (affected > 0)
                {
                    return Json(new { message = "Category deleted successfully" });
                }
                else
                {
                    return Json(new { message = "Error deleting category" });
                }
            }

        }
    }
}