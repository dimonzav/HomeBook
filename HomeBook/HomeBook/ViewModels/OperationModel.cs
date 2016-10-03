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
        private string name;
        private int operationTypeId;
        private DateTime date;
        private double? sum;
        private bool _isProductOperations;
        private bool _isSalary;
        private bool _isServiceOperations;
        private bool _isUtilities;
        private bool _isBank;

        public OperationModel()
        {
        }

        public OperationModel(Operation operation)
        {
            this.OperationTypeId = operation.OperationTypeId;
            this.Name = operation.Name;
            this.OperationTypeId = operation.OperationTypeId;
            this.OperationTypeModel = new OperationTypeModel(operation.OperationType);
            this.Date = operation.Date;
            this.Sum = operation.Sum;
            this.OperationProducts = new List<OperationProductModel>();

            if(operation.OperationProducts.Count > 0)
            {
                foreach (var prod in operation.OperationProducts)
                {
                    this.OperationProducts.Add(new OperationProductModel(prod));
                }
            }
        }

        public string OperationId { get; set; }

        [Required]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        [Required]
        public int OperationTypeId
        {
            get { return operationTypeId; }
            set
            {
                operationTypeId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual OperationTypeModel OperationTypeModel { get; set; }

        public virtual ICollection<OperationProductModel> OperationProducts { get; set; }

        [Required]
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                NotifyPropertyChanged();
            }
        }

        [Required]
        public double? Sum
        {
            get { return sum; }
            set
            {
                sum = value;
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

        public bool IsServicesOperations
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
    }
}
