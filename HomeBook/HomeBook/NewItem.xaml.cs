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
    public partial class NewItem : Window
    {
        private ItemTypes _itemType;
        public delegate void RefreshDel(int itemType);
        public event RefreshDel RefreshEvent;

        private Repo _repo;

        public NewItem(ItemTypes itemType)
        {
            InitializeComponent();

            this._repo = new Repo();
            this._itemType = itemType;

            forItemName.Content = "Enter " + this._itemType.ToString().ToLower() + " name";
            if(this._itemType == ItemTypes.ProductUnit)
            {
                forItemName.Content = "Enter product unit name";
            }
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (this.tbItemName.Text.Length > 0)
            {
                bool result = false;

                if (this._itemType == ItemTypes.Product)
                {
                    result = this._repo.AddProduct(this.tbItemName.Text);
                }
                else if (this._itemType == ItemTypes.Service)
                {
                    result = this._repo.AddService(this.tbItemName.Text);
                }
                else if (this._itemType == ItemTypes.ProductUnit)
                {
                    result = this._repo.AddProductUnit(this.tbItemName.Text);
                }
                else if (this._itemType == ItemTypes.Currency)
                {
                    result = this._repo.AddCurrency(this.tbItemName.Text);
                }
                else if (this._itemType == ItemTypes.Utility)
                {
                    result = this._repo.AddUtility(this.tbItemName.Text);
                }

                if (result)
                {
                    this.RefreshEvent((int)this._itemType);
                    this.Close();
                }
                else
                {
                    var resultMessageBox = MessageBox.Show("New product are not added! Retry", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
