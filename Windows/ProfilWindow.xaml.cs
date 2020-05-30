using AppSalesMan2.Repository;
using System.Windows;

namespace AppSalesMan2.Windows
{

    public partial class ProfilWindow : Window
    {
        readonly SalesMansRepository Repository = new SalesMansRepository();
        private readonly SalesMansModel _salesMansModel = new SalesMansModel();
        public ProfilWindow(SalesMansModel salesMansModel)
        {
            _salesMansModel = salesMansModel;
            InitializeComponent();
            FillTxtBox();
        }

        private void BtnSaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change your data", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                TxtBoxToModel();
                Repository.UpdateData(_salesMansModel);
                MessageBox.Show("Your data has been chenged");    
            }
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (txtOldPassword.Password != _salesMansModel.Password)
            {
                MessageBox.Show("Old password is incorrect");
            }
            else if (txtNewPassword.Password == "" || txtReNewPassword.Password == "" || txtOldPassword.Password == "")
            {
                MessageBox.Show("One of the boxes is empty");
            }
            else if (txtNewPassword.Password == txtReNewPassword.Password)
            {
                if (MessageBox.Show("Are you sure you want to change your password", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _salesMansModel.Password = txtNewPassword.Password;
                    Repository.UpdateData(_salesMansModel);
                }
                MessageBox.Show("Your Password has been chenged");
            }
            else MessageBox.Show("Passwords do not match");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow(_salesMansModel);
            menu.Show();
            this.Close();
        }

        public void FillTxtBox()
        {
            txtFirstName.Text = _salesMansModel.FirstName;
            txtLastName.Text = _salesMansModel.LastName;
            txtPhonenumber.Text = _salesMansModel.Phonenumber;
            txtEmail.Text = _salesMansModel.Email;
            txtDepartment.Text = _salesMansModel.Department;
            txtMenager.Text = _salesMansModel.Menager;
        }
        public void TxtBoxToModel()
        {
            
            _salesMansModel.FirstName = txtFirstName.Text;
            _salesMansModel.LastName = txtLastName.Text;
            _salesMansModel.Phonenumber = txtPhonenumber.Text;
            _salesMansModel.Email = txtEmail.Text;
            _salesMansModel.Department = txtDepartment.Text;
            _salesMansModel.Menager = txtMenager.Text;
        }
    }
}
