namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BankOperationType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankOperationTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
