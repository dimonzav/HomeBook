namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductUnit
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductUnitId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
