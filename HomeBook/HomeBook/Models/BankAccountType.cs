namespace HomeBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BankAccountType
    {
        [Key]
        public int BankAccountTypeId { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
