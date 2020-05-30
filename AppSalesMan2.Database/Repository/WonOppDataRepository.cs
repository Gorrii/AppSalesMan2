using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
  public class WonOppDataRepository
    {
        double CumulatedVolumen;
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<WonOppData> wonOppDatas => _DbContext.WonOppDatas;
        public ObservableCollection<WonOppData> GetWonOppData( int SalesManID)
        {
            ObservableCollection<WonOppData> wonOppData = new ObservableCollection<WonOppData>();
            using (var db = new AppSalesMan2DbContext())
            {

                var WonOpp = wonOppDatas.Where(x => x.SalesManId == SalesManID);
                foreach (var item in WonOpp)
                {
                    wonOppData.Add(new WonOppData()
                    {
                           WonOppId = item.WonOppId,
                           SalesManId = item.SalesManId,
                           WonOppName  = item.WonOppName,
                           WonOppEndCustomer = item.WonOppEndCustomer,
                           EstimatedOIDate = item.EstimatedOIDate,
                           WonOppVolumen = item.WonOppVolumen,
                           Accepted = item.Accepted
                    });
                }
            }
            return wonOppData;
        }

        public double GetCumulatedVolumen(int SalesManID)
        {
            
            using (var db = new AppSalesMan2DbContext())
            {
                var WonOpp = wonOppDatas.Where(x => x.SalesManId == SalesManID);
                foreach (var item in WonOpp)
                {
                    if (item.Accepted == true)
                    {
                        CumulatedVolumen += item.WonOppVolumen;
                    }
                    
                }
            }
            return CumulatedVolumen;
        }


        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
