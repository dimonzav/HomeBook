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
using HomeBook.ViewModels;

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        private Repo _repo;
        private OperationModel selectedOperation;

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

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedOperation = dgProducts.SelectedItem as OperationModel;
        }

        private void dgServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedOperation = dgServices.SelectedItem as OperationModel;
        }

        private void dgSalary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedOperation = dgSalary.SelectedItem as OperationModel;
        }

        private void dgBank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedOperation = dgBank.SelectedItem as OperationModel;
        }

        private void dgUtilities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedOperation = dgUtilities.SelectedItem as OperationModel;
        }

        private void btnRemoveOperation_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedOperation != null)
            {
                var result = this._repo.DeleteOperation(selectedOperation.OperationId);

                var operations = this._repo.GetOperations(selectedOperation.OperationTypeId);

                if (selectedOperation.OperationTypeId == 1)
                {
                    dgProducts.SelectedItem = operations[0];
                    dgProducts.ItemsSource = operations;
                    dgProducts.Items.Refresh();
                }
                else if (selectedOperation.OperationTypeId == 2)
                {
                    dgServices.SelectedItem = operations[0];
                    dgServices.ItemsSource = operations;
                    dgServices.Items.Refresh();
                }
                else if (selectedOperation.OperationTypeId == 3)
                {
                    dgSalary.SelectedItem = operations[0];
                    dgSalary.ItemsSource = operations;
                    dgSalary.Items.Refresh();
                }
                else if (selectedOperation.OperationTypeId == 4)
                {
                    dgBank.SelectedItem = operations[0];
                    dgBank.ItemsSource = operations;
                    dgBank.Items.Refresh();
                }
                else if (selectedOperation.OperationTypeId == 5)
                {
                    dgUtilities.SelectedItem = operations[0];
                    dgUtilities.ItemsSource = operations;
                    dgUtilities.Items.Refresh();
                }
            }
        }
    }
}
