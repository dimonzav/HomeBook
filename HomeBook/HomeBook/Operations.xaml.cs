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
using HomeBook.DataAccess;

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        private Repo _repo;

        public Operations()
        {
            InitializeComponent();

            this._repo = new Repo();
        }

        void tabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelectedTabIndex = tabCtrl.SelectedIndex;

            if (e.Source is TabControl)
            {
                this.RefreshOperations(currentSelectedTabIndex);
            }
        }

        private void btnAddOperation_Click(object sender, RoutedEventArgs e)
        {
            var selectedTabIndex = tabCtrl.SelectedIndex;
            AddOperation add = new AddOperation(selectedTabIndex);
            add.RefreshOperationsEvent += new AddOperation.RefreshDel(this.RefreshOperations);
            add.ShowDialog();
        }

        private void RefreshOperations(int operationTypeId)
        {
            if (operationTypeId == 0)
            {
                dgProducts.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
                dgProducts.Items.Refresh();
            }
            else if (operationTypeId == 1)
            {
                dgServices.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
                dgServices.Items.Refresh();
            }
            else if (operationTypeId == 2)
            {
                dgSalary.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
                dgSalary.Items.Refresh();
            }
            else if (operationTypeId == 3)
            {
                dgBank.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
                dgBank.Items.Refresh();
            }
            else if (operationTypeId == 4)
            {
                dgUtilities.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
                dgUtilities.Items.Refresh();
            }
            
        }
    }
}
