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
        private double _cardBalance;
        private double _creditCardLimit;
        private int _term;
        private double _accountAmount;
        private double _percentage;
        private double _depositPercentageSum;
        private double _creditDebt;

        public BankAccountModel()
        {
            this.IsCreditDeposit = true;
            this.IsDeposit = true;
        }

        public BankAccountModel(BankAccount account)
        {
            
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
                ChangeAccount();
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.IsCard));
                NotifyPropertyChanged(nameof(this.IsCreditCard));
                NotifyPropertyChanged(nameof(this.IsCreditDeposit));
                NotifyPropertyChanged(nameof(this.IsCredit));
                NotifyPropertyChanged(nameof(this.IsDeposit));
            }
        }

        public bool IsCard { get; set; }

        public bool IsCreditCard { get; set; }

        public bool IsCreditDeposit { get; set; }

        public bool IsCredit { get; set; }

        public bool IsDeposit { get; set; }

        [Required]
        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (value == _bankName) return;
                _bankName = value;
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
                NotifyPropertyChanged();
            }
        }

        public double CardBalance
        {
            get { return _cardBalance; }
            set
            {
                if (value == _cardBalance) return;
                _cardBalance = value;
                NotifyPropertyChanged();
            }
        }

        public double CreditCardLimit
        {
            get { return _creditCardLimit; }
            set
            {
                if (value == _creditCardLimit) return;
                _creditCardLimit = value;
                NotifyPropertyChanged();
            }
        }

        public int Term
        {
            get { return _term; }
            set
            {
                if (value == _term) return;
                _term = value;
                NotifyPropertyChanged();
            }
        }

        public double AccountAmount
        {
            get { return _accountAmount; }
            set
            {
                if (value == _accountAmount) return;
                _accountAmount = value;
                NotifyPropertyChanged();
            }
        }

        public double Percentage
        {
            get { return _percentage; }
            set
            {
                if (value == _percentage) return;
                _percentage = value;
                NotifyPropertyChanged();
            }
        }

        public double DepositPercentageSum
        {
            get { return _depositPercentageSum; }
            set
            {
                if (value == _depositPercentageSum) return;
                _depositPercentageSum = value;
                NotifyPropertyChanged();
            }
        }

        public double CreditDebt
        {
            get { return _creditDebt; }
            set
            {
                if (value == _creditDebt) return;
                _creditDebt = value;
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
    }
}
