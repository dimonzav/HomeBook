namespace HomeBook.ViewModels
{
    using HomeBook.Models;
    using System;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class OperationProductModel : INotifyPropertyChanged
    {
        private string name;
        private double? amount;
        private int _unitId;
        private double? price;
        private double? sum;

        public OperationProductModel()
        {
        }

        public OperationProductModel(OperationProduct item)
        {
            this.Name = item.Name;
            this.Amount = item.Amount;
            this.Price = item.Price;
            this.UnitId = item.UnitId;
            this.ProductUnit = item.ProductUnit;
            this.Sum = item.Sum;
        }        

        public string OperationProductId { get; set; }

        [Required]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.AllFieldsFilled));
            }
        }

        [Required]
        public double? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                CalcSum();
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.AllFieldsFilled));
            }
        }

        [Required]
        public int UnitId
        {
            get { return _unitId; }
            set
            {
                _unitId = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.AllFieldsFilled));
            }
        }

        public virtual ProductUnit ProductUnit { get; set; }

        [Required]
        public double? Price
        {
            get { return price; }
            set
            {
                price = value;
                CalcSum();
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(this.AllFieldsFilled));
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

        public bool AllFieldsFilled => Name.IsCleanText() && Amount.IsCleanNumber() && Price.IsCleanNumber() && ProductUnit != null;

        private void CalcSum()
        {
            Sum = amount * price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static explicit operator OperationProduct(OperationProductModel model)
        {
            if (model != null)
            {
                return new OperationProduct
                {
                    Name = model.Name,
                    OperationProductId = model.OperationProductId,
                    Amount = model.Amount,
                    Price = model.Price,
                    UnitId = model.UnitId,
                    Sum = model.Sum
                };
            }
            else
            {
                return null;
            }
        }
    }
}
