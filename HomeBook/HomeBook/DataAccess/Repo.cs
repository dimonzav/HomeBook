namespace HomeBook.DataAccess
{
    using HomeBook.Models;
    using HomeBook.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Repo
    {
        private HomeBookContext context;

        public Repo()
        {
            this.context = new HomeBookContext();
        }

        public Repo(HomeBookContext _context)
        {
            this.context = _context;
        }

        public List<OperationTypeModel> GetOperationTypes()
        {
            var typesDb = this.context.OperationsTypes.OrderBy(o => o.Order).ToList();

            List<OperationTypeModel> models = new List<OperationTypeModel>();

            if (typesDb.Count > 0)
            {
                foreach (var type in typesDb)
                {
                    OperationTypeModel model = new OperationTypeModel(type);

                    models.Add(model);
                }

                return models;
            }

            return null;
        }

        public bool AddProductUnit(string name)
        {
            this.context.ProductUnits.Add(new ProductUnit { Name = name });

            return this.context.SaveChanges() > 0;
        }

        public List<ProductUnit> GetProductUnits()
        {
            return this.context.ProductUnits.ToList();
        }

        public bool DeleteProductUnit(int productUnitId)
        {
            var deletedProductUnit = this.context.ProductUnits.FirstOrDefault(pu => pu.ProductUnitId == productUnitId);

            this.context.ProductUnits.Remove(deletedProductUnit);

            return this.context.SaveChanges() > 0;
        }

        public bool AddCurrency(string name)
        {
            this.context.Currencies.Add(new Currency { Name = name });

            return this.context.SaveChanges() > 0;
        }

        public List<Currency> GetCurrencies()
        {
            return this.context.Currencies.ToList();
        }

        public bool DeleteCurrency(int currencyId)
        {
            var deletedCurrency = this.context.Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);

            this.context.Currencies.Remove(deletedCurrency);

            return this.context.SaveChanges() > 0;
        }

        public bool AddUtility(string name)
        {
            this.context.Utilities.Add(new Utility { Name = name });

            return this.context.SaveChanges() > 0;
        }

        public List<Utility> GetUtilities()
        {
            return this.context.Utilities.ToList();
        }

        public bool DeleteUtility(int utilityId)
        {
            var deletedUtility = this.context.Utilities.FirstOrDefault(u => u.UtilityId == utilityId);

            this.context.Utilities.Remove(deletedUtility);

            return this.context.SaveChanges() > 0;
        }

        public List<SalaryOperationType> GetSalaryOperationTypes()
        {
            return this.context.SalaryOperationTypes.ToList();
        }

        public List<BankOperationType> GetBankOperationTypes()
        {
            return this.context.BankOperationTypes.ToList();
        }

        public List<OperationModel> GetOperations(int operationTypeId)
        {
            var operationsDb = this.context.Operations
                .Where(o => o.OperationTypeId == operationTypeId && !o.IsDeleted)
                .OrderByDescending(o => o.Date)
                .Include(p => p.OperationProducts)
                .ToList();

            List<OperationModel> operations = new List<OperationModel>();

            if (operationsDb.Count > 0)
            {
                foreach (var operation in operationsDb)
                {
                    OperationModel model = new OperationModel(operation);

                    operations.Add(model);
                }

                return operations;
            }

            return null;
        }

        public bool AddOperation(OperationModel operationModel)
        {
            if(operationModel != null)
            {
                Operation operation = new Operation
                {
                    OperationId = Guid.NewGuid().ToString(),
                    Name = operationModel.Name,
                    OperationTypeId = operationModel.OperationTypeId + 1,
                    Date = DateTime.Now,
                    Sum = operationModel.Sum,
                    SalaryOperationTypeId = operationModel.SalaryOperationTypeId + 1,
                    CurrencyId = operationModel.CurrencyId + 1,
                    ConvertedCurrencyId = operationModel.ConvertedCurrencyId + 1,
                    ConvertedValue = operationModel.ConvertedValue,
                    BankOperationTypeId = operationModel.BankOperationTypeId + 1,
                    BankAccountId = operationModel.BankAccountModel.BankAccountId,
                    UtilityId = operationModel.UtilityId + 1
                };

                if (operation.OperationTypeId == 1)
                {
                    //add products to operation entity
                    operationModel.OperationProducts.ToList().ForEach(a => operation.OperationProducts.Add((OperationProduct)a));

                    foreach (var product in operation.OperationProducts)
                    {
                        product.OperationProductId = Guid.NewGuid().ToString();
                    }

                    this.context.OperationProducts.AddRange(operation.OperationProducts);
                }
                else if (operation.OperationTypeId == 2)
                {
                    //add services to operation entity
                    operationModel.OperationServices.ToList().ForEach(a => operation.OperationServices.Add((OperationService)a));

                    foreach (var service in operation.OperationServices)
                    {
                        service.OperationServiceId = Guid.NewGuid().ToString();
                    }

                    this.context.OperationServices.AddRange(operation.OperationServices);
                }

                try
                {
                    this.context.Operations.Add(operation);

                    return this.context.SaveChanges() > 0;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine(
                            "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name,
                            eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine(
                                "- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName,
                                ve.ErrorMessage);
                        }
                    }

                    throw;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return false;
        }

        public bool DeleteOperation(string operationId)
        {
            var deletedOperation = this.context.Operations.Where(o => o.OperationId == operationId).FirstOrDefault();

            deletedOperation.IsDeleted = true;

            return this.context.SaveChanges() > 0;
        }

        public bool AddProduct(string name)
        {
            var product = new Product { Name = name };

            this.context.Products.Add(product);

            return this.context.SaveChanges() > 0;
        }

        public List<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public bool DeleteProduct(int producId)
        {
            var deletedProduct = this.context.Products.FirstOrDefault(p => p.ProductId == producId);

            this.context.Products.Remove(deletedProduct);

            return this.context.SaveChanges() > 0;
        }

        public bool AddService(string name)
        {
            var service = new Service { Name = name };

            this.context.Services.Add(service);

            return this.context.SaveChanges() > 0;
        }

        public List<Service> GetServices()
        {
            return this.context.Services.ToList();
        }

        public bool DeleteService(int serviceId)
        {
            var deletedService = this.context.Services.FirstOrDefault(p => p.ServiceId == serviceId);

            this.context.Services.Remove(deletedService);

            return this.context.SaveChanges() > 0;
        }

        public List<OperationModel> GetReportForOperations(ReportModel reportModel)
        {
            if (reportModel !=null)
            {
                List<Operation> operationsDb = new List<Operation>();

                List<OperationModel> models = new List<OperationModel>();

                var operationsQuery = this.context.Operations.Where(o => o.OperationTypeId == reportModel.OperationTypeId + 1 && !o.IsDeleted);

                if (!reportModel.IsForAllPeriod)
                {
                    if (reportModel.From != null)
                    {
                        operationsQuery = operationsQuery.Where(o => o.Date >= reportModel.From);
                    }

                    if (reportModel.To != null)
                    {
                        operationsQuery = operationsQuery.Where(o => o.Date <= reportModel.From);
                    }
                }

                if (reportModel.Sum != null && reportModel.Sum > 0)
                {
                    if (reportModel.IsEqual)
                    {
                        operationsQuery = operationsQuery.Where(o => o.Sum == reportModel.Sum);
                    }
                    else if (reportModel.IsGreater)
                    {
                        operationsQuery = operationsQuery.Where(o => o.Sum > reportModel.Sum);
                    }
                    else if (reportModel.IsLess)
                    {
                        operationsQuery = operationsQuery.Where(o => o.Sum < reportModel.Sum);
                    }
                }

                operationsDb = operationsQuery.OrderByDescending(o => o.Date).ToList();

                if (operationsDb.Count() > 0)
                {
                    foreach (var op in operationsDb)
                    {
                        OperationModel model = new OperationModel(op);

                        models.Add(model);
                    }

                    return models;
                }
            }

            return null;
        }

        public bool AddBankAccount(BankAccountModel bankAccountModel)
        {
            if(bankAccountModel != null)
            {
                BankAccount bankAccount = new BankAccount
                {
                    BankAccountId = Guid.NewGuid().ToString(),
                    BankAccountTypeId = bankAccountModel.BankAccountTypeId,
                    BankName = bankAccountModel.BankName,
                    AccountNumber = bankAccountModel.AccountNumber,
                    CardExpired = bankAccountModel.CardExpired,
                    CardBalance = bankAccountModel.CardBalance,
                    Percentage = bankAccountModel.Percentage,
                    Term = bankAccountModel.Term,
                    AccountAmount = bankAccountModel.Term,
                    CreditDebt = bankAccountModel.CreditDebt,
                    DepositPercentageSum = bankAccountModel.DepositPercentageSum
                };

                try
                {
                    this.context.BankAccounts.Add(bankAccount);

                    return this.context.SaveChanges() > 0;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine(
                            "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name,
                            eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine(
                                "- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName,
                                ve.ErrorMessage);
                        }
                    }

                    throw;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return false;
        }

        public List<BankAccountModel> GetBankAccounts(int bankAccountTypeId)
        {
            var bankAccountsDb = this.context.BankAccounts
                .Where(b => b.BankAccountTypeId == bankAccountTypeId && !b.IsDeleted)
                .ToList();

            List<BankAccountModel> bankAccounts = new List<BankAccountModel>();

            if (bankAccountsDb != null && bankAccountsDb.Count > 0)
            {
                foreach (var account in bankAccountsDb)
                {
                    BankAccountModel model = new BankAccountModel(account);

                    bankAccounts.Add(model);
                }

                return bankAccounts;
            }

            return null;
        }

        public bool DeleteBankAccount(string bankAccountId)
        {
            var deletedBankAccount = this.context.BankAccounts.Where(a => a.BankAccountId == bankAccountId).FirstOrDefault();

            deletedBankAccount.IsDeleted = true;

            return this.context.SaveChanges() > 0;
        }
    }
}
