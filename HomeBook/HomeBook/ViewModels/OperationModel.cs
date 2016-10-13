namespace HomeBook.ViewModels
{
    using HomeBook.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationModel : INotifyPropertyChanged
    {
        private string _name;
        private int _operationTypeId;
        private DateTime _date;
        private double? _sum;
        private int _salaryOperationTypeId;
        private int _currencyId;
        private int _convertedCurrencyId;
        private double? _convertedValue;
        private int _utilityTypeId;
        private int _bankOperationTypeId;
        private int _bankTypeId;
        private bool _isProductOperations = true;
        private bool _isSalary;
        private bool _isServiceOperations;
        private bool _isUtilities;
        private bool _isBank;

        public OperationModel()
        {
            this.Date = DateTime.Now;
        }

        public OperationModel(Operation operation)
        {
            this.OperationId = operation.OperationId;
            this.Name = operation.Name;
            this.OperationTypeId = operation.OperationTypeId;
            this.OperationTypeModel = new OperationTypeModel(operation.OperationType);
            this.Date = operation.Date;
            this.Sum = operation.Sum;
            this.SalaryOperationTypeId = operation.SalaryOperationTypeId;
            this.SalaryOperationType = operation.SalaryOperationType;
            this.CurrencyId = operation.CurrencyId;
            this.Currency = operation.Currency;
            this.ConvertedCurrencyId = operation.ConvertedCurrencyId;
            this.ConvertedValue = operation.ConvertedValue;
            this.BankOperationTypeId = operation.BankOperationTypeId;
            this.BankOperationType = operation.BankOperationType;
            this.BankAccountId = operation.BankAccountId;
            this.BankAccount = operation.BankAccount;
            this.UtilityId = operation.UtilityId;
            this.Utility = operation.Utility;
            this.OperationProducts = new List<OperationProductModel>();
            this.OperationServices = new List<OperationServiceModel>();

            if (operation.OperationProducts.Count > 0)
            {
                foreach (var prod in operation.OperationProducts)
                {
                    this.OperationProducts.Add(new OperationProductModel(prod));
                }
            }

            if (operation.OperationServices.Count > 0)
            {
                foreach (var prod in operation.OperationServices)
                {
                    this.OperationServices.Add(new OperationServiceModel(prod));
                }
            }
        }

        public string OperationId { get; set; }

        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                NotifyPropertyChanged();
            }
        }

        [Required]
        public int OperationTypeId
        {
            get { return _operationTypeId; }
            set
            {
                if (value == _operationTypeId) return;
                _operationTypeId = value;
                ChangeOperationType();
                NotifyPropertyChanged();
            }
        }

        public virtual OperationTypeModel OperationTypeModel { get; set; }

        public virtual ICollection<OperationProductModel> OperationProducts { get; set; }

        public virtual ICollection<OperationServiceModel> OperationServices { get; set; }

        [Required]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == _date) return;
                _date = value;
                NotifyPropertyChanged();
            }
        }

        public int SalaryOperationTypeId
        {
            get { return _salaryOperationTypeId; }
            set
            {
                if (value == _salaryOperationTypeId) return;
                _salaryOperationTypeId = value;
                this.ClearConvertedSalary();
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IsConvert));
            }
        }

        public virtual SalaryOperationType SalaryOperationType { get; set; }

        public bool IsConvert => SalaryOperationTypeId == 1;

        public int CurrencyId
        {
            get { return _currencyId; }
            set
            {
                if (value == _currencyId) return;
                _currencyId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual Currency Currency { get; set; }

        public int ConvertedCurrencyId
        {
            get { return _convertedCurrencyId; }
            set
            {
                if (value == _convertedCurrencyId) return;
                _convertedCurrencyId = value;
                NotifyPropertyChanged();
            }
        }

        public double? ConvertedValue
        {
            get { return _convertedValue; }
            set
            {
                if (value == _convertedValue) return;
                _convertedValue = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.ConvertedSalary));
            }
        }

        public double? ConvertedSalary => this.ConvertedValue * this.Sum;

        public int UtilityId
        {
            get { return _utilityTypeId; }
            set
            {
                if (value == _utilityTypeId) return;
                _utilityTypeId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual Utility Utility { get; set; }

        public int BankOperationTypeId
        {
            get { return _bankOperationTypeId; }
            set
            {
                if (value == _bankOperationTypeId) return;
                _bankOperationTypeId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual BankOperationType BankOperationType { get; set; }

        public int BankAccountId
        {
            get { return _bankTypeId; }
            set
            {
                if (value == _bankTypeId) return;
                _bankTypeId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual BankAccount BankAccount { get; set; }

        [Required]
        public double? Sum
        {
            get { return _sum; }
            set
            {
                if (value == _sum) return;
                _sum = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsProductOperations
        {
            get { return _isProductOperations; }
            set
            {
                if (value == _isProductOperations) return;
                _isProductOperations = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsSalary
        {
            get { return _isSalary; }
            set
            {
                if (value == _isSalary) return;
                _isSalary = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsServiceOperations
        {
            get { return _isServiceOperations; }
            set
            {
                if (value == _isServiceOperations) return;
                _isServiceOperations = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsUtilities
        {
            get { return _isUtilities; }
            set
            {
                if (value == _isUtilities) return;
                _isUtilities = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsBank
        {
            get { return _isBank; }
            set
            {
                if (value == _isBank) return;
                _isBank = value;
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

        public void ChangeOperationType()
        {
            this.IsProductOperations = this.IsServiceOperations = this.IsSalary = this.IsBank = this.IsUtilities = false;
            if (this.OperationTypeId == 0)
            {
                this.IsProductOperations = true;
            }
            else if (this.OperationTypeId == 1)
            {
                this.IsServiceOperations = true;
            }
            else if (this.OperationTypeId == 2)
            {
                this.IsSalary = true;
            }
            else if (this.OperationTypeId == 3)
            {
                this.IsBank = true;
            }
            else
            {
                this.IsUtilities = true;
            }
        } 

        public void ClearConvertedSalary()
        {
            if(this.SalaryOperationTypeId == 0)
            {
                this.ConvertedValue = null;
            }
        }
    }
}
