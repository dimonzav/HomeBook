namespace HomeBook.Migrations
{
    using HomeBook.DataAccess;
    using HomeBook.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeBook.DataAccess.HomeBookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.CommandTimeout = 60000;
        }

        protected override void Seed(HomeBookContext context)
        {
            context.OperationsTypes.AddOrUpdate(this.OperationTypes());

            context.Products.AddOrUpdate(this.Products());

            context.Operations.AddOrUpdate(this.Operations());
        }

        private OperationType[] OperationTypes()
        {
            List<OperationType> types = new List<OperationType>
            {
                new OperationType { OperationTypeId = 1, Name = "Charge" },
                new OperationType { OperationTypeId = 2, Name = "Write-Off" }
            };

            return types.ToArray();
        }

        private Product[] Products()
        {
            List<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Tomatoes" },
                new Product { ProductId = 2, Name = "Potatoes" },
                new Product { ProductId = 3, Name = "Bread" },
                new Product { ProductId = 4, Name = "Butter" },
                new Product { ProductId = 5, Name = "Meat" }
            };

            return products.ToArray();
        }

        private Operation[] Operations()
        {
            List<Operation> operations = new List<Operation>
            {
                new Operation { OperationId = "1", OperationTypeId = 1, Name = "Buy tomatoes", Date = new DateTime (2016, 08, 25), Sum = 25.5 },
                new Operation { OperationId = "2", OperationTypeId = 1, Name = "Buy potatoes", Date = new DateTime (2016, 07, 20), Sum = 20.50 },
                new Operation { OperationId = "3", OperationTypeId = 1, Name = "Buy bread", Date = new DateTime (2016, 08, 24), Sum = 12.25 },
                new Operation { OperationId = "4", OperationTypeId = 1, Name = "Buy butter", Date = new DateTime (2016, 08, 15), Sum = 25.5 },
                new Operation { OperationId = "5", OperationTypeId = 1, Name = "Buy meat", Date = new DateTime (2016, 08, 21), Sum = 260.00 }
            };

            return operations.ToArray(); 
        }
          
    }
}
