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
    /// Logika interakcji dla klasy MyRequestWindow.xaml
    /// </summary>
    public partial class MyRequestWindow : Window
    {
        ChangeRequestModelRepository repository = new ChangeRequestModelRepository();
        ChangeRequestModel requestModel = new ChangeRequestModel();
        public MyRequestWindow(int SalesManId)
        {
            requestModel.RequestList = repository.GetRequestList(SalesManId);
            InitializeComponent();
            DGRequest.DataContext = requestModel;
        }
    }
}
