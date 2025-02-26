using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using categoryPrac.Models;
using WorkingWithEFCore.AutoGen;
using Microsoft.EntityFrameworkCore;
using Northwind.Web.Model;
namespace categoryPrac.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WorkingWithEFCore.AutoGen.Northwind _db;

    public HomeController(ILogger<HomeController> logger, WorkingWithEFCore.AutoGen.Northwind db)
    {
        _logger = logger;
        _db = db;
    }
    public IActionResult Index()
    {
        DbSet<Category> categories = _db.Categories;
        // ViewData["categories"] = categories;
        ViewBag.Category = categories;
        return View();
    }

    public IActionResult Acerca()
    {
        return View();
    }

    public string HolaMundo(string nombre)
    {
        return "Hola mundo " + nombre;
    }

    [BindProperty]
    public Category _category { get; set; }
    public IActionResult CreateCategory()
    { //creamos el objeto de _category para poderlo agregar a la bd se supone
        long maxCategoryId = _db.Categories.Max(c => c.CategoryId) + 1;
        if (_db.Categories is null) return NotFound();
        _category.CategoryId = maxCategoryId;
        // return Json(_category);
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Category> 
        entity = _db.Categories.Add(_category);
        _db.SaveChanges();
        DbSet<Category> categories = _db.Categories;
        ViewBag.Category = categories;
        return RedirectToAction("Index");
    }
    public IActionResult DeleteCategory()
    {
        // return Json(_category);
        IQueryable<Category>? categories = _db.Categories?.Where
        (c => c.CategoryId.Equals(_category.CategoryId));
        if (categories is null || !categories.Any())
        {
            return NotFound();
        }
        else
        {
            if (_db.Categories is null) return NotFound();
            _db.Categories.RemoveRange(categories); //remove for 1
        }
        _db.SaveChanges();
        DbSet<Category> _categories = _db.Categories;
        ViewBag.Category = _categories;
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
