namespace HomeBook.DataAccess
{
    using HomeBook.Models;
    using HomeBook.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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

        public List<OperationModel> GetOperations()
        {
            var operationsDb = this.context.Operations.Include("OperationType").ToList();

            List<OperationModel> operations = new List<OperationModel>();

            if (operationsDb.Count > 0)
            {
                foreach (var operation in operationsDb)
                {
                    OperationModel model = new OperationModel
                    {
                        OperationId = operation.OperationId,
                        Name = operation.Name,
                        TypeId = operation.TypeId,
                        OperationTypeModel = new OperationTypeModel(operation.OperationType),
                        Time = operation.Time,
                        Sum = operation.Sum
                    };

                    operations.Add(model);
                }

                return operations;
            }

            return null;
        }
    }
}
