using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesCategory.Models;

namespace RazorPagesCategory.Data
{
    public class RazorPagesCategoryContext : DbContext
    {

        public RazorPagesCategoryContext(DbContextOptions<RazorPagesCategoryContext> options)
        :base(options){}
        
        public DbSet<Category> categories => Set<Category>();
    }
}