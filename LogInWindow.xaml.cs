using AppSalesMan2.Repository;
using AppSalesMan2.Windows;
using System.Windows;

namespace AppSalesMan2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        SalesMansModel salesMansModel = new SalesMansModel();
        public LogInWindow()
        { 
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SalesMansRepository salesMansRepository = new SalesMansRepository();
            salesMansModel = salesMansRepository.SalesManLogin(txtFirstName.Text, txtLastName.Text, txtPassword.Password);
            if (salesMansModel != null)
            {
                MenuWindow Menu = new MenuWindow(salesMansModel);
                Menu.Show();
                this.Close();
            }
            else
                MessageBox.Show("Incorrect password or login");
        }
    }
}
