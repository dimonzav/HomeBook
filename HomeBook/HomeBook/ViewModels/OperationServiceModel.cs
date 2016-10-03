namespace HomeBook.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using HomeBook.Models;

    public class OperationServiceModel : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private double? _sum;

        public OperationServiceModel()
        {
        }

        public OperationServiceModel(OperationService item)
        {
            this.Name = item.Name;
            this.Description = item.Description;
            this.Sum = item.Sum;
        }

        public string OperationServiceId { get; set; }

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
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                NotifyPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static explicit operator OperationService(OperationServiceModel model)
        {
            if (model != null)
            {
                return new OperationService
                {
                    Name = model.Name,
                    OperationServiceId = model.OperationServiceId,
                    Description = model.Description,
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
