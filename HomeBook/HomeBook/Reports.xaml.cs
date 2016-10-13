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
using HomeBook.DataAccess;

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        private Repo _repo;
        private ReportModel reportModel;
        private int selectedTabIndex;
        public Reports()
        {
            InitializeComponent();

            this._repo = new Repo();

            this.reportModel = this.DataContext as ReportModel;
        }

        void tabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedTabIndex = tabCtrl.SelectedIndex;
        }

        private void bntGetReport_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.GetReportForOperations(this.reportModel);

            dgProducts.ItemsSource = result;
        }
    }
}
