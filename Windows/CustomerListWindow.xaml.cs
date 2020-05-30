using AppSalesMan2.Database;
using AppSalesMan2.Database.Entity;
using AppSalesMan2.Database.Repository;
using AppSalesMan2.Repository;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using AppSalesMan2.Windows.ChangeWindows;

namespace AppSalesMan2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy CustomerList.xaml
    /// </summary>
    public partial class CustomerListWindow : Window
    {
        readonly CustomerModelRepository repository = new CustomerModelRepository();
        public readonly SalesMansModel _salesMansModel;
        public  CustomerModel CustomerList = new CustomerModel();
        public CustomerListWindow(SalesMansModel salesMansModel)
        {
            InitializeComponent();
            _salesMansModel = salesMansModel;
            CustomerList.CustomerList = repository.GetSalesManCustomerList(_salesMansModel.SalesManID);
            DGCompany.DataContext = CustomerList;
        }
       
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
             new MenuWindow(_salesMansModel).Show();
             this.Close();
        }

        private void NameChange_Click(object sender, RoutedEventArgs e)
        {
            if (DGCompany.SelectedItem is CustomerModel SelectedRow)
            {

                ChangeNameWindow changeNameWindow = new ChangeNameWindow(SelectedRow, this,_salesMansModel.SalesManID)
                {
                    Owner = this
                };
                changeNameWindow.ShowDialog();

            }
        }
        
         private void AsignedChange_Click(object sender, RoutedEventArgs e)
        {
            if (DGCompany.SelectedItem is CustomerModel SelectedRow)
            {

                ChangeResponsibleWindow changeResponsibleWindow = new ChangeResponsibleWindow(SelectedRow, this, _salesMansModel.SalesManID)
                {
                    Owner = this
                };
                changeResponsibleWindow.ShowDialog();

            }
        }

        private void ChangeCityAndPostcode_Click(object sender, RoutedEventArgs e)
        {
            if (DGCompany.SelectedItem is CustomerModel SelectedRow)
            {

                ChangeCityAndPostcodeWindow changeCityAndPostcodeWindow = new ChangeCityAndPostcodeWindow(SelectedRow, this, _salesMansModel.SalesManID)
                {
                    Owner = this
                };
                changeCityAndPostcodeWindow.ShowDialog();

            }
        }

        private void ChangeIndustry_Click(object sender, RoutedEventArgs e)
        {
            if (DGCompany.SelectedItem is CustomerModel SelectedRow)
            {

                ChangeIndustryWindow changeCityAndPostcodeWindow = new ChangeIndustryWindow(SelectedRow, this, _salesMansModel.SalesManID)
                {
                    Owner = this
                };
                changeCityAndPostcodeWindow.ShowDialog();

            }
        }

        private void ChangeLogistic_Click(object sender, RoutedEventArgs e)
        {
            if (DGCompany.SelectedItem is CustomerModel SelectedRow)
            {

                ChangeLogisticWindow changeCityAndPostcodeWindow = new ChangeLogisticWindow(SelectedRow, this, _salesMansModel.SalesManID)
                {
                    Owner = this
                };
                changeCityAndPostcodeWindow.ShowDialog();

            }
        }

        private void ShowRequestList_Click(object sender, RoutedEventArgs e)
        {
            new MyRequestWindow(_salesMansModel.SalesManID).Show();
            
        }
    }
}
