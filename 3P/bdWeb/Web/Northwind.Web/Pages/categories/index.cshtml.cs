using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkingWithEFCore.AutoGen;

namespace Northwind.Web.Pages.categories
{
    public class indexModel : PageModel
    {
        private readonly WorkingWithEFCore.AutoGen.Northwind _context;

        public indexModel(WorkingWithEFCore.AutoGen.Northwind context)
        {
            _context = context;
        }

        public IList<Category> category {get; set;} = default!;


        public async Task OnGetAsync()
        {
            if(_context.Categories != null)
            {
                category = await _context.Categories.ToListAsync();
            }
        }
    }
}