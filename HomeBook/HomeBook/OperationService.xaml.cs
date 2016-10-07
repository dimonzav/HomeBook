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
    /// Interaction logic for OperationService.xaml
    /// </summary>
    public partial class OperationService : Window
    {
        private Repo _repo;
        private OperationServiceModel operationService;

        public delegate void AddServiceDel(OperationServiceModel operationProduct);
        public event AddServiceDel AddServiceEvent;

        public OperationService()
        {
            InitializeComponent();

            this._repo = new Repo();
            this.operationService = this.DataContext as OperationServiceModel;

            cbServices.ItemsSource = this._repo.GetServices();
            cbServices.DisplayMemberPath = "Name";
        }

        private void btnAddNewService_Click(object sender, RoutedEventArgs e)
        {
            AddService addNewService = new AddService();
            addNewService.RefreshServicesEvent += new AddService.RefreshDel(this.RefreshServices);
            addNewService.ShowDialog();
        }

        private void RefreshServices()
        {
            cbServices.ItemsSource = this._repo.GetServices();
            cbServices.Items.Refresh();
        }

        private void cbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedService = cbServices.SelectedItem as Service;
            this.operationService.Name = selectedService.Name;
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            this.AddServiceEvent(operationService);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
