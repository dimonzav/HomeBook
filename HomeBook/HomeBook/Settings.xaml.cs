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

        public Settings()
        {
            InitializeComponent();

            this._repo = new Repo();
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
            //if (bankAccountTypeId == 0)
            //{
            //    dgSalaryCards.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
            //    dgSalaryCards.Items.Refresh();
            //}
            //else if (bankAccountTypeId == 1)
            //{
            //    dgCreditCards.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
            //    dgCreditCards.Items.Refresh();
            //}
            //else if (bankAccountTypeId == 2)
            //{
            //    dgDebitCards.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
            //    dgDebitCards.Items.Refresh();
            //}
            //else if (bankAccountTypeId == 3)
            //{
            //    dgCredits.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
            //    dgCredits.Items.Refresh();
            //}
            //else if (bankAccountTypeId == 4)
            //{
            //    dgDeposits.ItemsSource = this._repo.GetOperations(operationTypeId + 1);
            //    dgDeposits.Items.Refresh();
            //}
        }
    }
}
