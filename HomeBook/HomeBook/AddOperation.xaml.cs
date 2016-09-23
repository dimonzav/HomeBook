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
        private OperationProductModel operationProduct;
        private OperationModel operation;

        public AddOperation()
        {
            InitializeComponent();

            this._repo = new Repo();   
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            OperationProduct addProductWindow = new OperationProduct();
            addProductWindow.AddProductEvent += new OperationProduct.AddProductDel(this.AddProductToOperation);
            addProductWindow.ShowDialog();
        }

        private void AddProductToOperation(OperationProductModel operationProduct)
        {

        }
    }
}
