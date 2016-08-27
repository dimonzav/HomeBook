namespace HomeBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationType
    {
        [Key]
        public int OperationTypeId { get; set; }

        public string Name { get; set; }
    }
}
