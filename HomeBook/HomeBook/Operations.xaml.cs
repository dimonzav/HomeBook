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

            var operations = this._repo.GetOperations();

            dgOperagions.ItemsSource = operations;
        }

        private void btnAddOperation_Click(object sender, RoutedEventArgs e)
        {
            AddOperation add = new AddOperation();
            add.ShowDialog();
        }
    }
}
