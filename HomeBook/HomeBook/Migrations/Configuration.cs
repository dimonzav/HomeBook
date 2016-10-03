namespace HomeBook.Migrations
{
    using DataAccess;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeBookContext>
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
                new OperationType { OperationTypeId = 1, Name = "None", Order = 1 },
                new OperationType { OperationTypeId = 1, Name = "Product", Order = 2 },
                new OperationType { OperationTypeId = 2, Name = "Service", Order = 3 },
                new OperationType { OperationTypeId = 3, Name = "Salary", Order = 4 },
                new OperationType { OperationTypeId = 4, Name = "Bank", Order = 5 },
                new OperationType { OperationTypeId = 5, Name = "Utilities", Order = 6 }
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

        private Currency[] Currency()
        {
            List<Currency> currency = new List<Currency>
            {
                new Currency { Name = "USD" },
                new Currency { Name = "UAH" },
                new Currency { Name = "EUR" }
            };

            return currency.ToArray();
        }

        private Utility[] Utilities()
        {
            List<Utility> utilities = new List<Utility>
            {
                new Utility { Name = "Water" },
                new Utility { Name = "Gas" },
                new Utility { Name = "Electricity" }
            };

            return utilities.ToArray();
        }

        private BankOperationType[] BankOperations()
        {
            List<BankOperationType> bankOperations = new List<BankOperationType>
            {
                new BankOperationType { BankOperationId = 0, Name = "Deposit" },
                new BankOperationType { BankOperationId = 1, Name = "Credit" },
                new BankOperationType { BankOperationId = 2, Name = "Deposit %" }
            };

            return bankOperations.ToArray();
        }
          
    }
}
