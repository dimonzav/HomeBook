namespace HomeBook.DataAccess
{
    using HomeBook.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeBookContext : DbContext
    {
        public HomeBookContext() : base("DefaultConnection")
        {
            this.Database.CommandTimeout = 180;
        }

        public virtual DbSet<Operation> Operations { get; set; }

        public virtual DbSet<OperationType> OperationsTypes { get; set; }

        public virtual DbSet<Product> Products { get; set; }
    }
}
