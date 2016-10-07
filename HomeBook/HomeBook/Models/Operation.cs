namespace HomeBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Operation
    {
        public Operation()
        {
            this.OperationProducts = new HashSet<OperationProduct>();
            this.OperationServices = new HashSet<OperationService>();
        }
        [Key]
        public string OperationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        public virtual OperationType OperationType { get; set; }

        public virtual ICollection<OperationProduct> OperationProducts { get; set; }

        public virtual ICollection<OperationService> OperationServices { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double? Sum { get; set; }

        public int SalaryOperationTypeId { get; set; }

        public virtual SalaryOperationType SalaryOperationType { get; set; }

        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public int ConvertedCurrencyId { get; set; }

        public double? ConvertedValue { get; set; }

        public int UtilityId { get; set; }

        public virtual Utility Utility { get; set; }

        public int BankOperationTypeId { get; set; }

        public virtual BankOperationType BankOperationType { get; set; }

        public int BankAccountId { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public bool IsDeleted { get; set; }

    }
}
