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

            context.BankOperationTypes.AddOrUpdate(this.BankOperations());

            context.BankAccountTypes.AddOrUpdate(this.BankAccountTypes());

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

        private BankOperationType[] BankOperations()
        {
            List<BankOperationType> bankOperations = new List<BankOperationType>
            {
                new BankOperationType { BankOperationTypeId = 1, Name = "Credit card enroll" },
                new BankOperationType { BankOperationTypeId = 2, Name = "Credit card widthdraw" },
                new BankOperationType { BankOperationTypeId = 3, Name = "Debit card enroll" },
                new BankOperationType { BankOperationTypeId = 4, Name = "Debit card widthdraw" },
                new BankOperationType { BankOperationTypeId = 5, Name = "Credit repayment" },
                new BankOperationType { BankOperationTypeId = 6, Name = "Deposit percentages widthdrawal" }
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
                new SalaryOperationType { SalaryOperationTypeId = 2, Name = "Withdrawal" }
            };

            return types.ToArray();
        }

    }
}
