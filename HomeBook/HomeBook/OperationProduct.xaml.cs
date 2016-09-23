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
    /// Interaction logic for OperationProduct.xaml
    /// </summary>
    public partial class OperationProduct : Window
    {
        private Repo _repo;
        private OperationProductModel operationProduct;

        public delegate void AddProductDel(OperationProductModel operationProduct);
        public event AddProductDel AddProductEvent;

        public OperationProduct()
        {
            InitializeComponent();

            this._repo = new Repo();
            this.operationProduct = new OperationProductModel();

            cbProducts.ItemsSource = this._repo.GetProducts();
            cbProducts.DisplayMemberPath = "Name";
        }
        
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProductWindow = new NewProduct();
            newProductWindow.RefreshProductsEvent += new NewProduct.RefreshDel(this.RefreshProducts);
            newProductWindow.ShowDialog();
        }

        private void RefreshProducts()
        {
            cbProducts.ItemsSource = this._repo.GetProducts();
            cbProducts.Items.Refresh();
        }

        private void cbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedProduct = cbProducts.SelectedItem as string;
            this.operationProduct.Name = selectedProduct;
        }

        private void btnAddOperationProduct_Click(object sender, RoutedEventArgs e)
        {
            this.AddProductEvent(operationProduct);
        }

        private void btnCanceAddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
