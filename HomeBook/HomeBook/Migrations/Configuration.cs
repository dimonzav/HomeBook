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

            context.ProductUnits.AddOrUpdate(this.ProductUnits());

            context.Currencies.AddOrUpdate(this.Currency());

            context.BankOperationTypes.AddOrUpdate(this.BankOperations());

            context.BankAccountTypes.AddOrUpdate(this.BankAccountTypes());

            context.Utilities.AddOrUpdate(this.Utilities());

            context.SalaryOperationTypes.AddOrUpdate(this.SalaryTypes());
        }

        private OperationType[] OperationTypes()
        {
            List<OperationType> types = new List<OperationType>
            {
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

        private ProductUnit[] ProductUnits()
        {
            List<ProductUnit> units = new List<ProductUnit>
            {
                new ProductUnit { ProductUnitId = 1, Name = "kg" },
                new ProductUnit { ProductUnitId = 2, Name = "gram" },
                new ProductUnit { ProductUnitId = 3, Name = "piece" },
                new ProductUnit { ProductUnitId = 4, Name = "bottle" },
                new ProductUnit { ProductUnitId = 5, Name = "bundle" }
            };

            return units.ToArray();
        }

        private Currency[] Currency()
        {
            List<Currency> currency = new List<Currency>
            {
                new Currency { CurrencyId = 1, Name = "USD" },
                new Currency { CurrencyId = 2, Name = "UAH" },
                new Currency { CurrencyId = 3, Name = "EUR" }
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
                new BankOperationType { BankOperationTypeId = 1, Name = "Deposit" },
                new BankOperationType { BankOperationTypeId = 2, Name = "Credit" },
                new BankOperationType { BankOperationTypeId = 3, Name = "Deposit %" }
            };

            return bankOperations.ToArray();
        }

        private BankAccountType[] BankAccountTypes()
        {
            List<BankAccountType> accountTypes = new List<BankAccountType>
            {
                new BankAccountType { BankAccountTypeId = 1, TypeName = "Salary card" },
                new BankAccountType { BankAccountTypeId = 2, TypeName = "Credit card" },
                new BankAccountType { BankAccountTypeId = 3, TypeName = "Debit card" },
                new BankAccountType { BankAccountTypeId = 4, TypeName = "Credit" },
                new BankAccountType { BankAccountTypeId = 5, TypeName = "Deposit" }
            };

            return accountTypes.ToArray();
        }

        private SalaryOperationType[] SalaryTypes()
        {
            List<SalaryOperationType> types = new List<SalaryOperationType>
            {
                new SalaryOperationType { SalaryOperationTypeId = 1, Name = "Enrollment" },
                new SalaryOperationType { SalaryOperationTypeId = 2, Name = "Widthdrawal" }
            };

            return types.ToArray();
        }

    }
}
