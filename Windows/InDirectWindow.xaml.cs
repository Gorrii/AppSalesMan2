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
    /// Logika interakcji dla klasy InDirectWindow.xaml
    /// </summary>
    public partial class InDirectWindow : Window
    {
        IndirectModelRepository SumIndirectRepository = new IndirectModelRepository();
        IndirectModel SumIndirect = new IndirectModel();
        private SalesMansModel _salesMansModel;
        IndirectModel indirect = new IndirectModel();
       
        public InDirectWindow(SalesMansModel SalesMan)
        {
            _salesMansModel = SalesMan;
            
            InitializeComponent();
            FillGridAndTxtBox();
            DGIndirectQ1.DataContext = indirect;
            DGIndirectQ2.DataContext = indirect;
            DGIndirectQ3.DataContext = indirect;
            DGIndirectQ4.DataContext = indirect;
          
        }







        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(_salesMansModel).Show();
            this.Close();
        }

        public void FillGridAndTxtBox()
        {
            for (int i = 1; i < 5; i++)
            {
            IndirectModelRepository repository = new IndirectModelRepository();
                if (i==1)
                {
                    indirect.IndirectQ1 = repository.GetIndirectList(_salesMansModel.SalesManID, 2020, 1);
                }
                if (i==2)
                {
                    indirect.IndirectQ2 = repository.GetIndirectList(_salesMansModel.SalesManID, 2020, 2);
                }
                if (i==3)
                {
                    indirect.IndirectQ3 = repository.GetIndirectList(_salesMansModel.SalesManID, 2020, 3);
                }
                if (i==4)
                {
                    indirect.IndirectQ4 = repository.GetIndirectList(_salesMansModel.SalesManID, 2020, 4);
                }
            }

            SumIndirect = SumIndirectRepository.GetQuaterSum(_salesMansModel.SalesManID, 2020);
            txtSumQ1.Text = SumIndirect.SumQ1.ToString();
            txtSumQ2.Text = SumIndirect.SumQ2.ToString();
            txtSumQ3.Text = SumIndirect.SumQ3.ToString();
            txtSumQ4.Text = SumIndirect.SumQ4.ToString();
        }
    }
}
