using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Service
{
    public class ProductsDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
