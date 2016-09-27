namespace HomeBook.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class ReportModel : INotifyPropertyChanged
    {
        private bool _isProductOperations;
        private bool _isSalary;
        private bool _isCosts;
        private bool _isUtilities;
        private bool _isBank;
        private bool _isForAllPeriod;

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

        public bool IsCosts
        {
            get { return _isCosts; }
            set
            {
                if (value == _isCosts) return;
                _isCosts = value;
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

        public bool IsForAllPeriod
        {
            get { return _isForAllPeriod; }
            set
            {
                if (value == _isForAllPeriod) return;
                _isForAllPeriod = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsSummary { get; set; }

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
