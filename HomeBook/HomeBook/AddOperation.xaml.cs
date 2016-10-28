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
    /// Interaction logic for AddOperation.xaml
    /// </summary>
    public partial class AddOperation : Window
    {
        private Repo _repo;
        private List<OperationProductModel> productList;
        private List<OperationServiceModel> serviceList;
        private OperationModel operation;

        public delegate void RefreshDel(int operationTypeId);
        public event RefreshDel RefreshOperationsEvent;

        public AddOperation()
        {
            InitializeComponent();
        }

        public AddOperation(int operationTypeId)
        {
            InitializeComponent();

            this._repo = new Repo();
            this.productList = new List<OperationProductModel>();
            this.serviceList = new List<OperationServiceModel>();
            this.operation = this.DataContext as OperationModel;

            this.operation.OperationTypeId = operationTypeId;

            cbOperationType.ItemsSource = this._repo.GetOperationTypes();
            cbOperationType.DisplayMemberPath = "Name";
            cbSalaryType.ItemsSource = this._repo.GetSalaryOperationTypes();
            cbSalaryType.DisplayMemberPath = "Name";
            cbBankAccount.ItemsSource = this._repo.GetBankAccounts(1);
            cbBankAccount.DisplayMemberPath = "BankName";
            cbSalaryCurrency.ItemsSource = this._repo.GetCurrencies();
            cbSalaryCurrency.DisplayMemberPath = "Name";
            cbConvertedCurrency.ItemsSource = this._repo.GetCurrencies();
            cbConvertedCurrency.DisplayMemberPath = "Name";
            cbBankOperationType.ItemsSource = this._repo.GetBankOperationTypes();
            cbBankOperationType.DisplayMemberPath = "Name";
            cbUtilities.ItemsSource = this._repo.GetUtilities();
            cbUtilities.DisplayMemberPath = "Name";
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            OperationProduct addProductWindow = new OperationProduct();
            addProductWindow.AddProductEvent += new OperationProduct.AddProductDel(this.AddProductToOperation);
            addProductWindow.ShowDialog();
        }

        private void AddProductToOperation(OperationProductModel operationProduct)
        {
            this.productList.Add(operationProduct);
            dgOperationProducts.ItemsSource = this.productList;
            dgOperationProducts.Items.Refresh();
            this.operation.OperationProducts = this.productList;
            this.operation.Sum = this.GetSumFromAllProducts(this.productList);
        }

        private double? GetSumFromAllProducts(List<OperationProductModel> items)
        {
            double? total = 0;
            foreach (var item in items)
            {
                total += item.Sum;
            }

            return total;
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            OperationService addServiceWindow = new OperationService();
            addServiceWindow.AddServiceEvent += new OperationService.AddServiceDel(this.AddServiceToOperation);
            addServiceWindow.ShowDialog();
        }

        private void AddServiceToOperation(OperationServiceModel operationService)
        {
            this.serviceList.Add(operationService);
            dgOperationServices.ItemsSource = this.serviceList;
            dgOperationServices.Items.Refresh();
            this.operation.OperationServices = this.serviceList;
            this.operation.Sum = this.GetSumFromAllServices(this.serviceList);
        }

        private double? GetSumFromAllServices(List<OperationServiceModel> items)
        {
            double? total = 0;
            foreach (var item in items)
            {
                total += item.Sum;
            }

            return total;
        }

        private void btnAddOpration_Click(object sender, RoutedEventArgs e)
        {
            this._repo.AddOperation(this.operation);
            this.RefreshOperationsEvent(this.operation.OperationTypeId);
            this.Close();
        }

        private void cbBankOperationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.operation.OperationTypeId == 3)
            {
                var selectedBankOperation = this.operation.BankOperationTypeId;
                var bankAccountTypeId = 0;

                if (selectedBankOperation == 0 || selectedBankOperation == 1)
                {
                    bankAccountTypeId = 2;
                }
                else if (selectedBankOperation == 2 || selectedBankOperation == 3)
                {
                    bankAccountTypeId = 3;
                }
                else if (selectedBankOperation == 4)
                {
                    bankAccountTypeId = 4;
                }
                else if (selectedBankOperation == 5)
                {
                    bankAccountTypeId = 5;
                }

                var result = this._repo.GetBankAccounts(bankAccountTypeId);

                if (result != null)
                {
                    cbBankAccount.ItemsSource = result;
                    cbBankAccount.Items.Refresh();
                }
            }
        }

        private void btnCancelAddOperation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
