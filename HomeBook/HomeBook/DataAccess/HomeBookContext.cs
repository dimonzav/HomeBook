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

        public virtual DbSet<OperationProduct> OperationProducts { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<OperationService> OperationServices { get; set; }

        public virtual DbSet<ProductUnit> ProductUnits { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Utility> Utilities { get; set; }

        public virtual DbSet<BankOperationType> BankOperationTypes { get; set; }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }

        public virtual DbSet<BankAccountType> BankAccountTypes { get; set; }

        public virtual DbSet<SalaryOperationType> SalaryOperationTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operation>().HasOptional(b => b.BankAccount);
        }
    }
}
