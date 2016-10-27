namespace HomeBook.ViewModels
{
    using HomeBook.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BankAccountModel : INotifyPropertyChanged
    {
        private int _bankAccountTypeId;
        private string _bankName;
        private string _accountNumber;
        private string _cardExpired;
        private double? _cardBalance;
        private double? _creditCardLimit;
        private bool _allFieldsFilled;
        private int? _term;
        private double? _accountAmount;
        private double? _percentage;
        private double? _depositPercentageSum;
        private double? _creditDebt;

        public BankAccountModel()
        {

        }

        public BankAccountModel(BankAccount account)
        {
            this.BankAccountId = account.BankAccountId;
            this.BankAccountTypeId = account.BankAccountTypeId;
            this.BankAccountTypeModel = new BankAccountTypeModel(account.BankAccountType);
            this.BankName = account.BankName;
            this.AccountNumber = account.AccountNumber;
            this.CardExpired = account.CardExpired;
            this.CardBalance = account.CardBalance;
            this.CreditCardLimit = account.CreditCardLimit;
            this.Percentage = account.Percentage;
            this.Term = account.Term;
            this.AccountAmount = account.AccountAmount;
            this.DepositPercentageSum = account.DepositPercentageSum;
            this.CreditDebt = account.CreditDebt;
        }

        [Key]
        public string BankAccountId { get; set; }

        [Required]
        public int BankAccountTypeId
        {
            get { return _bankAccountTypeId; }
            set
            {
                if (value == _bankAccountTypeId) return;
                _bankAccountTypeId = value;
                this.ChangeAccount();
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.IsCard));
                NotifyPropertyChanged(nameof(this.IsCreditCard));
                NotifyPropertyChanged(nameof(this.IsCreditDeposit));
                NotifyPropertyChanged(nameof(this.IsCredit));
                NotifyPropertyChanged(nameof(this.IsDeposit));
            }
        }

        public virtual BankAccountTypeModel BankAccountTypeModel { get; set; }

        public bool IsCard { get; set; }

        public bool IsCreditCard { get; set; }

        public bool IsCreditDeposit { get; set; }

        public bool IsCredit { get; set; }

        public bool IsDeposit { get; set; }

        public bool AllFieldsFilled
        {
            get { return _allFieldsFilled; }
            set
            {
                if (value == _allFieldsFilled) return;
                _allFieldsFilled = value;
                NotifyPropertyChanged();
            }
        }

        [Required]
        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (value == _bankName) return;
                _bankName = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        [Required]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value == _accountNumber) return;
                _accountNumber = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public string CardExpired
        {
            get { return _cardExpired; }
            set
            {
                if (value == _cardExpired) return;
                _cardExpired = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? CardBalance
        {
            get { return _cardBalance; }
            set
            {
                if (value == _cardBalance) return;
                _cardBalance = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? CreditCardLimit
        {
            get { return _creditCardLimit; }
            set
            {
                if (value == _creditCardLimit) return;
                _creditCardLimit = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public int? Term
        {
            get { return _term; }
            set
            {
                if (value == _term) return;
                _term = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? AccountAmount
        {
            get { return _accountAmount; }
            set
            {
                if (value == _accountAmount) return;
                _accountAmount = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? Percentage
        {
            get { return _percentage; }
            set
            {
                if (value == _percentage) return;
                _percentage = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? DepositPercentageSum
        {
            get { return _depositPercentageSum; }
            set
            {
                if (value == _depositPercentageSum) return;
                _depositPercentageSum = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public double? CreditDebt
        {
            get { return _creditDebt; }
            set
            {
                if (value == _creditDebt) return;
                _creditDebt = value;
                this.CheckForAllFieldsFilled();
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ChangeAccount()
        {
            if (this.BankAccountTypeId == 1 || this.BankAccountTypeId == 2 || this.BankAccountTypeId == 3)
            {
                this.IsCard = true;
            }

            if (this.BankAccountTypeId == 2)
            {
                this.IsCreditCard = true;
            }

            if (this.BankAccountTypeId == 4 || this.BankAccountTypeId == 5)
            {
                this.IsCreditDeposit = true;
            }

            if (this.BankAccountTypeId == 4)
            {
                this.IsCredit = true;
            }

            if(this.BankAccountTypeId == 5)
            {
                this.IsDeposit = true;
            }
        }

        private void CheckForAllFieldsFilled()
        {
            if (this.IsCard && this.IsCreditCard)
            {
                this.AllFieldsFilled = this.BankName.IsCleanText() && this.AccountNumber.IsCleanText() && this.CardExpired.IsCleanText() && this.CardBalance.IsCleanNumber() && this.CreditCardLimit.IsCleanNumber();
            }
            else if (this.IsCard)
            {
                this.AllFieldsFilled = this.BankName.IsCleanText() && this.AccountNumber.IsCleanText() && this.CardExpired.IsCleanText() && this.CardBalance.IsCleanNumber();
            }
            else if (this.IsCreditDeposit && this.IsDeposit)
            {
                this.AllFieldsFilled = this.BankName.IsCleanText() && this.AccountNumber.IsCleanText() && this.Percentage.IsCleanNumber() && this.Term.IsCleanNumber() && this.AccountAmount.IsCleanNumber() && this.DepositPercentageSum.IsCleanNumber();
            }
            else if (this.IsCreditDeposit && this.IsCredit)
            {
                this.AllFieldsFilled = this.BankName.IsCleanText() && this.AccountNumber.IsCleanText() && this.Percentage.IsCleanNumber() && this.Term.IsCleanNumber() && this.AccountAmount.IsCleanNumber() && this.CreditDebt.IsCleanNumber();
            }
        }
    }
}
