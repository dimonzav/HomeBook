namespace HomeBook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BankAccount
    {
        [Key]
        public string BankAccountId { get; set; }

        [Required]
        public int BankAccountTypeId { get; set; }

        public virtual BankAccountType BankAccountType { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        public string CardExpired { get; set; }

        public double? CardBalance { get; set; }

        public double? CreditCardLimit { get; set; }

        public int? Term { get; set; }

        public double? AccountAmount { get; set; }

        public double? Percentage { get; set; }

        public double? DepositPercentageSum { get; set; }

        public double? CreditDebt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
