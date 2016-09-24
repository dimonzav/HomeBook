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
        private int operationType;
        private DateTime date;
        private double? sum;

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
            get { return operationType; }
            set
            {
                operationType = value;
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
