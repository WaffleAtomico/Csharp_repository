using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace categoryPrac.Controllers
{
    // [Route("[controller]")]
    public class Usuarios : Controller
    {
        // private readonly ILogger<Usuarios> _logger;

        // public Usuarios(ILogger<Usuarios> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View();
        }

        //bool encontrado = false;

        public IActionResult Registro(bool encontrado)
        {
            if(encontrado)
            {
                 return Content("Registro encotnrado");
            }else
            {
                 return StatusCode(404);
            }
           
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}