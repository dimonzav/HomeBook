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
        }
        [Key]
        public string OperationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        public virtual OperationType OperationType { get; set; }

        public virtual ICollection<OperationProduct> OperationProducts { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double? Sum { get; set; }
    }
}
