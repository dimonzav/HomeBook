namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BankOperationType
    {
        [Key]
        [Required]
        public int BankOperationTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
