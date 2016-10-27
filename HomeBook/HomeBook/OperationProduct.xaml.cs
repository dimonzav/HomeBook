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
using HomeBook.Models;

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
            this.operationProduct = this.DataContext as OperationProductModel;

            cbProducts.ItemsSource = this._repo.GetProducts();
            cbProducts.DisplayMemberPath = "Name";
            cbProductUnit.ItemsSource = this._repo.GetProductUnits();
            cbProductUnit.DisplayMemberPath = "Name";
        }
        
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NewItem newProductWindow = new NewItem(ItemTypes.Product);
            newProductWindow.RefreshEvent += new NewItem.RefreshDel(this.RefreshProducts);
            newProductWindow.ShowDialog();
        }

        private void RefreshProducts(int itemType)
        {
            cbProducts.ItemsSource = this._repo.GetProducts();
            cbProducts.Items.Refresh();
        }

        private void cbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = cbProducts.SelectedItem as Product;
            this.operationProduct.Name = selectedProduct.Name;
        }

        private void cbProductUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUnit = cbProductUnit.SelectedItem as ProductUnit;
            this.operationProduct.Unit = selectedUnit.Name;
        }

        private void btnAddOperationProduct_Click(object sender, RoutedEventArgs e)
        {
            this.AddProductEvent(operationProduct);
            this.Close();
        }

        private void btnCanceAddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
