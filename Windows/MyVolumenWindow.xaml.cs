using AppSalesMan2.Models;
using AppSalesMan2.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Logika interakcji dla klasy MyVolumenWindow.xaml
    /// </summary>
    public partial class MyVolumenWindow : Window
    {
        private readonly SalesMansModel _salesMansModel;
        public   string CompanyName;
        readonly CustomerVolumenModelRepository repository = new CustomerVolumenModelRepository();
        readonly CustomerVolumenModel volumenModels = new CustomerVolumenModel();


        public MyVolumenWindow(SalesMansModel SalesMan)
        {
            _salesMansModel = SalesMan;
            volumenModels.CustomerVolumen = repository.GetSortedVolumenList(SalesMan.SalesManID);
            InitializeComponent();
            DGVolumen.DataContext = volumenModels;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(_salesMansModel).Show();
            this.Close();
        }

        private void DGVolumen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGVolumen.SelectedItem is CustomerVolumenModel SelectedRow)
            {
                volumenModels.VolumenPerMonth = repository.GetSelectedCustomerVolumen(_salesMansModel.SalesManID, SelectedRow.CustomerId);
                DGPerMonth.DataContext = volumenModels;
            }
        }
    }
}
