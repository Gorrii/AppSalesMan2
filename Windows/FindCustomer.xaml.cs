using AppSalesMan2.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppSalesMan2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy FindCustomer.xaml
    /// </summary>
    public partial class FindCustomer : Window
    {
        private SalesMansModel _salesMan;
        CustomerModel CustomerModel = new CustomerModel();
        CustomerModelRepository modelRepository = new CustomerModelRepository();
        public FindCustomer(SalesMansModel salesMansModel )
        {
            
            _salesMan = salesMansModel;

            InitializeComponent();
            DGFindResult.DataContext = CustomerModel;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(_salesMan).Show();
            
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
          CustomerModel.CustomerList = modelRepository.SearchList(txtName.Text, txtSAP.Text, txtIFA.Text, txtPostCode.Text, txtCity.Text, txtIndustry.Text, txtLogistic.Text);

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtIFA.Text = "";
            txtSAP.Text = "";
            txtCity.Text = "";
            txtPostCode.Text = "";
            txtLogistic.Text = "";
            txtIndustry.Text = "";
            CustomerModel.CustomerList = modelRepository.SearchList(txtName.Text, txtSAP.Text, txtIFA.Text, txtPostCode.Text, txtCity.Text, txtIndustry.Text, txtLogistic.Text);

        }
    }
}
