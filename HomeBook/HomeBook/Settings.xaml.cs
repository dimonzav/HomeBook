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
    /// Interaction logic for Units.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private Repo _repo;
        private BankAccountModel selectedBankAccount;

        public Settings()
        {
            InitializeComponent();

            this._repo = new Repo();

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
    }
}
