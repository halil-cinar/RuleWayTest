using Microsoft.EntityFrameworkCore;
using RuleWayTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayTest.DataAccess.Context
{
    public class DatabaseContext:DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Initial Catalog=RuleWayTest; Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }



    }
}
