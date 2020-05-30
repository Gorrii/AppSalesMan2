using LiveCharts;
using System;
using System.Collections.Generic;
using System.Text;

using LiveCharts.Wpf;

namespace AppSalesMan2.Repository
{
     public class ChartRepository
    {
        public SeriesCollection SeriesCollection { get; set; }
        double Krzywa;
        double Realization;
        public string[] LabelsFIll = new string[140];
        ChartValues<double> Bonus = new ChartValues<double>();
        ChartValues<double> ActualBonus = new ChartValues<double>();
        public SeriesCollection seriesViews( int BonusValue)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "BOSE20",
                    Values = FIllcurve(),
                    LineSmoothness = 0,
                    PointGeometrySize =0,

                },
                 new LineSeries
                {
                    Title = "ActualBonus",
                    Values = FIllActualcurve(BonusValue),
                    LineSmoothness = 0,
                    PointGeometrySize =0,

                }
            };

            return SeriesCollection;
        }

        public ChartValues<double> FIllcurve()
        {
            for (int i = 0; i < 160; i++)
            {
                Krzywa += 5;
                if (i < 80)
                {
                    Krzywa = 0;
                }
                if (i > 139)
                {
                    Krzywa = 300;
                }
                Bonus.Add(Krzywa);
            }
            return Bonus;
        }
        public ChartValues<double> FIllActualcurve(int BonusValue)
        {
            for (int i = 0; i < BonusValue; i++)
            {
                Realization += 5;
                if (i < 80)
                {
                    Realization = 0;
                }
                if (i > 139)
                {
                    Realization = 300;
                }
                ActualBonus.Add(Realization);
            }
            return ActualBonus;
        }

        public string[] FillActualCurve()
        {
            for (int i = 0; i < 140; i++)
            {

                Realization += 1;
                LabelsFIll[i] = Realization.ToString();
            }
            return LabelsFIll;
        }

    }
}
