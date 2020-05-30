using AppSalesMan2.Models;
using AppSalesMan2.Repository;
using System.Windows;

namespace AppSalesMan2.Windows.ChangeWindows
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeNameWindow.xaml
    /// </summary>
    public partial class ChangeNameWindow : Window
    {
        private readonly int _Id;
        readonly CustomerListWindow CustomerListWindow;
        readonly CustomerModel SelectedCustomer = new CustomerModel();
        readonly ChangeRequestModelRepository ChangeRepository = new ChangeRequestModelRepository();
        readonly CustomerModelRepository Repository = new CustomerModelRepository();
        public ChangeNameWindow(CustomerModel SelectedRow, CustomerListWindow customerListWindow, int SalesManId )
        {
            _Id = SalesManId;
            this.CustomerListWindow = customerListWindow;
            this.SelectedCustomer = SelectedRow;
            InitializeComponent();
            txtExistingName.Text = SelectedRow.Name;
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            ChangeRequestModel NewRequest = new ChangeRequestModel
            {
                CompanyID = SelectedCustomer.CompanyID, 
                Parameter = SelectedCustomer.Name,
                NewParameter = txtNewName.Text,
                Action = "ChangeCompanyName",
                SalesManId = _Id

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
