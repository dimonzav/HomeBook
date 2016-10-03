namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OperationService
    {
        [Key]
        [Required]
        public string OperationServiceId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public double? Sum { get; set; }
    }
}
