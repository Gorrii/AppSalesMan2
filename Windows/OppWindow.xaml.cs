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

namespace AppSalesMan2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy OppWindow.xaml
    /// </summary>
    public partial class OppWindow : Window
    {
        private SalesMansModel _salesMans;
        public WonOppModel WonOpp = new WonOppModel();
        public WonOppModelRepository ModelRepository = new WonOppModelRepository();
        public OppWindow(SalesMansModel salesMansModel)
        {
            _salesMans = salesMansModel;
            WonOpp.WonOppList = ModelRepository.GetWonOppList(_salesMans.SalesManID);
            InitializeComponent();
            DGWonOpp.DataContext = WonOpp;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(_salesMans).Show();
            this.Close();
        }
    }
}
