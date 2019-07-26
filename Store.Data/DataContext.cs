using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class DataContext : DbContext
    {
        public DbSet<ProductDL> Products { get; set; }
        public DbSet<CategoryDL> Categories { get; set; }

        public DataContext() : base("Store")
        {
            //
        }

        public DataContext(string connectionString) : base(connectionString)
        {
            //
        }
    }
}
