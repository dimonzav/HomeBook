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
using HomeBook.ViewModels;
using HomeBook.DataAccess;

namespace HomeBook
{
    /// <summary>
    /// Interaction logic for AddBankAccounts.xaml
    /// </summary>
    public partial class AddBankAccounts : Window
    {
        private Repo _repo;
        private BankAccountModel bankAccountModel;

        public delegate void RefreshDel(int bankAccountTypeId);
        public event RefreshDel RefreshBankAccountsEvent;

        public AddBankAccounts(int _bankAccountTypeId)
        {
            InitializeComponent();

            this._repo = new Repo();
            this.bankAccountModel = this.DataContext as BankAccountModel;
            this.bankAccountModel.BankAccountTypeId = _bankAccountTypeId;
        }

        public AddBankAccounts()
        {
            InitializeComponent();
        }

        private void btnAddBankAccount_Click(object sender, RoutedEventArgs e)
        {
            var result = this._repo.AddBankAccount(this.bankAccountModel);
            this.RefreshBankAccountsEvent(this.bankAccountModel.BankAccountTypeId);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
