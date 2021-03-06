﻿namespace HomeBook.ViewModels
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
        private bool _isForAllPeriod;
        private int _operationTypeId;
        private double? _sum;
        private bool _isEqual;
        private bool _isGreater;
        private bool _isLess;

        public ReportModel()
        {
            this.From = DateTime.Now;
            this.To = DateTime.Now;
        }

        public int OperationTypeId
        {
            get { return _operationTypeId; }
            set
            {
                if (value == _operationTypeId) return;
                _operationTypeId = value;
                NotifyPropertyChanged();
            }
        }

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

        public bool IsEqual
        {
            get { return _isEqual; }
            set
            {
                if (value == _isEqual) return;
                _isEqual = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsGreater
        {
            get { return _isGreater; }
            set
            {
                if (value == _isGreater) return;
                _isGreater = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsLess
        {
            get { return _isLess; }
            set
            {
                if (value == _isLess) return;
                _isLess = value;
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

        //public int TypeId { get; set; }

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
