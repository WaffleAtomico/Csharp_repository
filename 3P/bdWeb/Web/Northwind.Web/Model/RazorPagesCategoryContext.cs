using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Web.Model
{
    public class RazorPagesCategoryContext : DbContext
    {
        public RazorPagesCategoryContext(DbContextOptions<RazorPagesCategoryContext> options)
        :base(options)
        {}
         public DbSet<category> categories => Set<category>();
    }
}