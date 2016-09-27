using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HomeBook.ViewModels;

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        private ReportModel reportModel;
        public Reports()
        {
            InitializeComponent();

            this.reportModel = this.DataContext as ReportModel;
        }

        private void bntGetReport_Click(object sender, RoutedEventArgs e)
        {
            var report = this.reportModel;
        }
    }
}
