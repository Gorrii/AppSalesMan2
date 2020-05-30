using System.Windows;

namespace AppSalesMan2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly SalesMansModel _salesMansModel = new SalesMansModel();
        public MenuWindow(SalesMansModel salesMansModel)
        {
            _salesMansModel = salesMansModel;
            
            InitializeComponent();
            if (_salesMansModel.Department == "AREA/OEM")
                btnIndirect.IsEnabled = true;
            else
                btnIndirect.IsEnabled = false;
            txtBlockName.Text = salesMansModel.FirstName;
           
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow profil = new ProfilWindow(_salesMansModel);
            profil.Show();
            this.Close();
            
        }

        private void CustomerList_Click(object sender, RoutedEventArgs e)
        {
            new CustomerListWindow(_salesMansModel).Show();
            this.Close();
        }

        private void btmDirect_Click(object sender, RoutedEventArgs e)
        {
            new MyVolumenWindow(_salesMansModel).Show();
            this.Close();
        }

        private void btnBonusProgres_Click(object sender, RoutedEventArgs e)
        {
            new BonusProgressWindow(_salesMansModel).Show();
            this.Close();

        }

        private void Indirect_Click(object sender, RoutedEventArgs e)
        {
            
            new InDirectWindow(_salesMansModel).Show();
            this.Close();
        }

        private void btnOpp_Click(object sender, RoutedEventArgs e)
        {
            new OppWindow(_salesMansModel).Show();
            this.Close();
        }

        private void BtnRegionAssigned_Click(object sender, RoutedEventArgs e)
        {
            new FindCustomer(_salesMansModel).Show();
            this.Close();
        }
    }
}
