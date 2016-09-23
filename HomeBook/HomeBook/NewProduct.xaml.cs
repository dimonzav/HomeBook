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
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public delegate void RefreshDel();
        public event RefreshDel RefreshProductsEvent;

        private Repo _repo;

        public NewProduct()
        {
            InitializeComponent();

            this._repo = new Repo();
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.AddProduct(this.tbProductName.Text);

            if (result)
            {
                this.RefreshProductsEvent();
                this.Close();
            }
            else
            {
                var resultMessageBox = MessageBox.Show("New product are not added! Retry", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
