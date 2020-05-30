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
using AppSalesMan2.Models;
using AppSalesMan2.Repository;
using LiveCharts;
using LiveCharts.Wpf;
using Separator = System.Windows.Controls.Separator;

namespace AppSalesMan2.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy BonusProgressWindow.xaml
    /// </summary>
    public partial class BonusProgressWindow : Window
    {
        double ActualBV=0;
        double ActualIndirect=0;
        double ActualOpp=0;
        double Plan;
        int Realization;
        double ActualDirectIndirectOpp;
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        private SalesMansModel _salesMan;
        readonly WonOppModelRepository oppModelRepository = new WonOppModelRepository();
        readonly CustomerVolumenModelRepository repository = new CustomerVolumenModelRepository();
        readonly CustomerVolumenModel volumenModels = new CustomerVolumenModel();
        readonly PlansModelRepository plansRepository = new PlansModelRepository();
        readonly ChartRepository chartRepository = new ChartRepository();
        
        public BonusProgressWindow(SalesMansModel salesMans)
        {
            InitializeComponent();
            _salesMan = salesMans;
            volumenModels.CustomerVolumen = repository.GetAllSelectedBY(_salesMan.SalesManID, 2020);
            CalculateAllVolumen();
            FillTxtBox();
            
            
            
            DGVolumen.DataContext = volumenModels;
           
           
            
            Labels = chartRepository.FillActualCurve();
            SeriesCollection = chartRepository.seriesViews(Realization);
            Chart.DataContext = this;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(_salesMan).Show();
            this.Close();
        }

     
        public void CalculateAllVolumen()
        {
            //Dla każdego zawsze jest DIRECT
            foreach (var item in volumenModels.CustomerVolumen)
            {
                ActualBV += item.BVBY20;
            }
            //OPP tylko dla VSS i AREA/OEM
            if (_salesMan.Department == "VSS" || _salesMan.Department == "AREA/OEM")
            {
                //Liczy OPP
                ActualOpp = oppModelRepository.GetCumulatedVolumen(_salesMan.SalesManID);
                ActualDirectIndirectOpp += ActualOpp;
            }
            if (_salesMan.Department == "AREA/OEM")
            {
                IndirectModel Indirect = new IndirectModel();
                IndirectModelRepository indirectModelRepository = new IndirectModelRepository();
                Indirect = indirectModelRepository.GetQuaterSum(_salesMan.SalesManID, 2020);
                ActualIndirect = Indirect.SumAll;
                ActualDirectIndirectOpp += ActualIndirect; 
            }
            ActualDirectIndirectOpp += ActualBV;
            Plan= plansRepository.GetPlans(_salesMan.SalesManID);
            Realization =Convert.ToInt32( (ActualDirectIndirectOpp/Plan ) *100);

          
        }

        public void FillTxtBox()
        {
           
            txtRealization.Text = Realization.ToString() + "%";
            txtPlan.Text = Plan.ToString();
            txtActualIndirectAndDirect.Text = ActualDirectIndirectOpp.ToString();
            txtActualDirectBV.Text = ActualBV.ToString();
            if(_salesMan.Department == "AREA/OEM")
            txtActualIndirect.Text = ActualIndirect.ToString();
            else
            txtActualIndirect.Text ="N/A";
            if (_salesMan.Department == "VSS" || _salesMan.Department == "AREA/OEM")
                txtActualOppWon.Text = ActualOpp.ToString();
            else
                txtActualOppWon.Text = "N/A";
        }
    }

}
