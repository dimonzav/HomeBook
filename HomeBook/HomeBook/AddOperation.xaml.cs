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
        private OperationModel operation;

        public delegate void RefreshDel();
        public event RefreshDel RefreshOperationsEvent;

        public AddOperation()
        {
            InitializeComponent();

            this._repo = new Repo();
            this.productList = new List<OperationProductModel>();
            this.operation = this.DataContext as OperationModel;

            cbOperationType.ItemsSource = this._repo.GetOperationTypes();
            cbOperationType.DisplayMemberPath = "Name";
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

        private void btnCancelAddOperation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbOperationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = cbOperationType.SelectedItem as OperationTypeModel;
            this.operation.OperationTypeId = selectedType.OperationTypeId;
        }

        private void btnAddOpration_Click(object sender, RoutedEventArgs e)
        {
            this._repo.AddOperation(this.operation);
            this.RefreshOperationsEvent();
        }
    }
}
