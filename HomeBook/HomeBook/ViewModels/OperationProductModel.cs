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
        private int amount;
        private string unit;
        private double price;
        private double sum;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CalcSum()
        {
            Sum = amount * price;
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
            }
        }

        [Required]
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                CalcSum();
                NotifyPropertyChanged();
            }
        }

        [Required]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                NotifyPropertyChanged();
            }
        }

        [Required]
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                CalcSum();
                NotifyPropertyChanged();
            }
        }

        [Required]
        public double Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                NotifyPropertyChanged();
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
                    Unit = model.Unit,
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
