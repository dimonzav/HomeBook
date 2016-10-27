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
    /// Interaction logic for Units.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private Repo _repo;
        private BankAccountModel selectedBankAccount;
        private object seletedItem;

        public Settings()
        {
            InitializeComponent();

            this._repo = new Repo();


            lbProducts.ItemsSource = this._repo.GetProducts();
            lbProducts.DisplayMemberPath = "Name";
            lbServices.ItemsSource = this._repo.GetServices();
            lbServices.DisplayMemberPath = "Name";

            lbProductUnits.ItemsSource = this._repo.GetProductUnits();
            lbProductUnits.DisplayMemberPath = "Name";
            lbCurrencies.ItemsSource = this._repo.GetCurrencies();
            lbCurrencies.DisplayMemberPath = "Name";
            lbUtilities.ItemsSource = this._repo.GetUtilities();
            lbUtilities.DisplayMemberPath = "Name";

            dgSalaryCards.ItemsSource = this._repo.GetBankAccounts(1);
            dgSalaryCards.DisplayMemberPath = "Name";
            dgCreditCards.ItemsSource = this._repo.GetBankAccounts(2);
            dgCreditCards.DisplayMemberPath = "Name";
            dgDebitCards.ItemsSource = this._repo.GetBankAccounts(3);
            dgDebitCards.DisplayMemberPath = "Name";
            dgCredits.ItemsSource = this._repo.GetBankAccounts(4);
            dgCredits.DisplayMemberPath = "Name";
            dgDeposits.ItemsSource = this._repo.GetBankAccounts(5);
            dgDeposits.DisplayMemberPath = "Name";
        }

        private void addNewItem(object sender, RoutedEventArgs e)
        {
            var itemType = (ItemTypes)Convert.ToInt32(((Button)sender).Tag);
            NewItem newProductWindow = new NewItem(itemType);
            newProductWindow.RefreshEvent += new NewItem.RefreshDel(this.RefreshItems);
            newProductWindow.ShowDialog();
        }

        private void RefreshItems(int itemType)
        {
            if (itemType == (int)ItemTypes.Product)
            {
                lbProducts.ItemsSource = this._repo.GetProducts();
                lbProducts.Items.Refresh();
            }
            else if(itemType == (int)ItemTypes.Service)
            {
                lbServices.ItemsSource = this._repo.GetServices();
                lbServices.Items.Refresh();
            }
            else if (itemType == (int)ItemTypes.ProductUnit)
            {
                lbProductUnits.ItemsSource = this._repo.GetProductUnits();
                lbProductUnits.Items.Refresh();
            }
            else if (itemType == (int)ItemTypes.Currency)
            {
                lbCurrencies.ItemsSource = this._repo.GetCurrencies();
                lbCurrencies.Items.Refresh();
            }
            else if (itemType == (int)ItemTypes.Utility)
            {
                lbUtilities.ItemsSource = this._repo.GetUtilities();
                lbUtilities.Items.Refresh();
            }
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.DeleteProduct((this.seletedItem as Product).ProductId);
            this.RefreshItems((int)ItemTypes.Product);
        }

        private void btnRemoveService_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.DeleteService((this.seletedItem as Service).ServiceId);
            this.RefreshItems((int)ItemTypes.Service);
        }

        private void btnRemoveProductUnit_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.DeleteProductUnit((this.seletedItem as ProductUnit).ProductUnitId);
            this.RefreshItems((int)ItemTypes.ProductUnit);
        }

        private void btnRemoveCurrency_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.DeleteCurrency((this.seletedItem as Currency).CurrencyId);
            this.RefreshItems((int)ItemTypes.Currency);
        }

        private void btnRemoveUtility_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.DeleteUtility((this.seletedItem as Utility).UtilityId);
            this.RefreshItems((int)ItemTypes.Utility);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.seletedItem = ((ListBox)sender).SelectedItem;
        }

        private void btnAddBankAccount(object sender, RoutedEventArgs e)
        {
            var selectedBankAccountType = Convert.ToInt32(((Button)sender).Tag);
            AddBankAccounts bankAccount = new AddBankAccounts(selectedBankAccountType);
            bankAccount.RefreshBankAccountsEvent += new AddBankAccounts.RefreshDel(this.RefreshBankAccounts);
            bankAccount.ShowDialog();
        }

        private void RefreshBankAccounts(int bankAccountTypeId)
        {
            if (bankAccountTypeId == 1)
            {
                dgSalaryCards.ItemsSource = this._repo.GetBankAccounts(bankAccountTypeId);
                dgSalaryCards.Items.Refresh();
            }
            else if (bankAccountTypeId == 2)
            {
                dgCreditCards.ItemsSource = this._repo.GetBankAccounts(bankAccountTypeId);
                dgCreditCards.Items.Refresh();
            }
            else if (bankAccountTypeId == 3)
            {
                dgDebitCards.ItemsSource = this._repo.GetBankAccounts(bankAccountTypeId);
                dgDebitCards.Items.Refresh();
            }
            else if (bankAccountTypeId == 4)
            {
                dgCredits.ItemsSource = this._repo.GetBankAccounts(bankAccountTypeId);
                dgCredits.Items.Refresh();
            }
            else if (bankAccountTypeId == 5)
            {
                dgDeposits.ItemsSource = this._repo.GetBankAccounts(bankAccountTypeId);
                dgDeposits.Items.Refresh();
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedBankAccount = ((DataGrid)sender).SelectedItem as BankAccountModel;
        }

        private void RemoveBankAccount(object sender, RoutedEventArgs e)
        {
            if (this.selectedBankAccount != null)
            {
                var result = this._repo.DeleteBankAccount(this.selectedBankAccount.BankAccountId);

                if (result)
                {
                    this.RefreshBankAccounts(this.selectedBankAccount.BankAccountTypeId);
                }
                else
                {
                    var resultMessageBox = MessageBox.Show("Bank account is not deleted", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }
    }
}
