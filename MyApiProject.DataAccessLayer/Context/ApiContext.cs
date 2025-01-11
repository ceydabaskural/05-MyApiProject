using Microsoft.EntityFrameworkCore;
using MyApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.DataAccessLayer.Context
{
    public class ApiContext : DbContext
    {
        //sql bağlantımızı yazmak için:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F5CBDSU\\SQLEXPRESS;initial Catalog=ApiNewDb;integrated security=true;Trusted_Connection=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
