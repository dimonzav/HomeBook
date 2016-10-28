namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OperationProduct
    {
        [Key]
        [Required]
        public string OperationProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public int UnitId { get; set; }

        public virtual ProductUnit ProductUnit { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public double? Sum { get; set; }

    }
}
