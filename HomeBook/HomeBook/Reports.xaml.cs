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

        public Reports()
        {
            InitializeComponent();

            this._repo = new Repo();

            this.reportModel = this.DataContext as ReportModel;
        }

        private void bntGetReport_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.GetReportForOperations(this.reportModel);

            if (result != null && result.Count > 0)
            {
                if (this.reportModel.OperationTypeId == 0)
                {
                    dgProducts.ItemsSource = result;
                    dgProducts.Items.Refresh();
                }
                else if (this.reportModel.OperationTypeId == 1)
                {
                    dgServices.ItemsSource = result;
                    dgServices.Items.Refresh();
                }
                else if (this.reportModel.OperationTypeId == 2)
                {
                    dgSalary.ItemsSource = result;
                    dgSalary.Items.Refresh();
                }
                else if (this.reportModel.OperationTypeId == 3)
                {
                    dgBank.ItemsSource = result;
                    dgBank.Items.Refresh();
                }
                else if (this.reportModel.OperationTypeId == 4)
                {
                    dgUtilities.ItemsSource = result;
                    dgUtilities.Items.Refresh();
                }
            }
            else
            {
                var resultMessageBox = MessageBox.Show("There is no operation by your request", "Attention!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }
    }
}
