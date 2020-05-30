using AppSalesMan2.Models;
using AppSalesMan2.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppSalesMan2.Windows.ChangeWindows
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeResponsibleWindow.xaml
    /// </summary>
    public partial class ChangeResponsibleWindow : Window
    {
        private readonly int _Id;
        readonly CustomerListWindow CustomerListWindow;
        readonly CustomerModel SelectedCustomer = new CustomerModel();
        readonly ChangeRequestModelRepository ChangeRepository = new ChangeRequestModelRepository();
        readonly CustomerModelRepository Repository = new CustomerModelRepository();
        public ChangeResponsibleWindow(CustomerModel SelectedRow, CustomerListWindow customerListWindow, int SalesManId)

        {
            _Id = SalesManId;
            this.CustomerListWindow = customerListWindow;
            this.SelectedCustomer = SelectedRow;
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            ChangeRequestModel NewRequest = new ChangeRequestModel
            {
                CompanyID = SelectedCustomer.CompanyID,
                Parameter = CustomerListWindow._salesMansModel.LastName,
                NewParameter = txtLastName.Text,
                SalesManId = _Id,
                Action = "ChangeSalesManAsigned"
               
            };
            ChangeRepository.AddRequest(NewRequest);
            Repository.ChangeRequest(SelectedCustomer);
            CustomerListWindow.CustomerList.CustomerList = Repository.GetSalesManCustomerList(_Id);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
