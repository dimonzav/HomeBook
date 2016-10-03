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
            var typesDb = this.context.OperationsTypes.ToList();

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

        public List<OperationModel> GetOperations()
        {
            var operationsDb = this.context.Operations.Include("OperationType").Include(p => p.OperationProducts).ToList();

            List<OperationModel> operations = new List<OperationModel>();

            if (operationsDb.Count > 0)
            {
                foreach (var operation in operationsDb)
                {
                    OperationModel model = new OperationModel
                    {
                        OperationId = operation.OperationId,
                        Name = operation.Name,
                        OperationTypeId = operation.OperationTypeId,
                        OperationTypeModel = new OperationTypeModel(operation.OperationType),
                        Date = operation.Date,
                        Sum = operation.Sum
                    };

                    List<OperationProductModel> tempList = new List<OperationProductModel>();

                    if (operation.OperationProducts.Count > 0)
                    {
                        foreach (var product in operation.OperationProducts)
                        {
                            OperationProductModel productModel = new OperationProductModel(product);

                            tempList.Add(productModel);
                        }

                        model.OperationProducts = tempList.ToArray();
                    }

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
                    OperationTypeId = operationModel.OperationTypeId,
                    Date = DateTime.Now,
                    Sum = operationModel.Sum
                };

                operationModel.OperationProducts.ToList().ForEach(a => operation.OperationProducts.Add((OperationProduct)a));

                foreach (var product in operation.OperationProducts)
                {
                    product.OperationProductId = Guid.NewGuid().ToString();
                }

                try
                {
                    this.context.OperationProducts.AddRange(operation.OperationProducts);

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

        public bool AddProduct(string name)
        {
            var product = new Product { Name = name };

            this.context.Products.Add(product);

            return this.context.SaveChanges() > 0;
        }

        public bool AddService(string name)
        {
            var service = new Service { Name = name };

            this.context.Services.Add(service);

            return this.context.SaveChanges() > 0;
        }

        public List<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public List<Service> GetServices()
        {
            return this.context.Services.ToList();
        }

        public List<OperationModel> GetReportForOperations(ReportModel reportModel)
        {
            if (reportModel !=null)
            {
                List<Operation> operationsDb = new List<Operation>();

                List<OperationModel> models = new List<OperationModel>();

                var operationsQuery = Enumerable.Empty<Operation>().AsQueryable();

                if (reportModel.IsProductOperations)
                {
                    if (reportModel.IsForAllPeriod)
                    {
                        operationsQuery = this.context.Operations.Where(o => o.OperationTypeId == 1);
                    }
                    else {
                        if (reportModel.From != null)
                        {
                            operationsQuery = operationsQuery.Where(o => o.Date >= reportModel.From);
                        }

                        if (reportModel.To != null)
                        {
                            operationsQuery = operationsQuery.Where(o => o.Date <= reportModel.From);
                        }
                    }
                }

                operationsDb = operationsQuery.ToList();

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
    }
}
