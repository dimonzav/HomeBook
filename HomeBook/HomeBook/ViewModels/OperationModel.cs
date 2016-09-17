namespace HomeBook.ViewModels
{
    using HomeBook.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationModel
    {
        public string OperationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual OperationTypeModel OperationTypeModel { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public double Sum { get; set; }
    }
}
