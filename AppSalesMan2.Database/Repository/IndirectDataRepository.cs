using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
     public class IndirectDataRepository
    {
        readonly ObservableCollection<IndirectData> IndirectVolumenPerQuarter = new ObservableCollection<IndirectData>();
        readonly ObservableCollection<IndirectData> IndirectVolumenAll = new ObservableCollection<IndirectData>();
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<IndirectData> IndirectDatas => _DbContext.IndirectDatas;

       
        public ObservableCollection<IndirectData> GetIndirectYearAndQuater(int SalesManId, int Year , int Quater)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var Indirect = IndirectDatas.Where(x => x.SalesManId == SalesManId && x.Year == Year && x.Quarter == Quater);
                foreach (var item in Indirect)
                {
                    IndirectVolumenPerQuarter.Add(new IndirectData()
                    {
                       DystrCustomer = item.DystrCustomer,
                        Volumen = item.Volumen
                    });
                }
            }

            return IndirectVolumenPerQuarter;
        }
        public ObservableCollection<IndirectData> GetAllInDirect(int SalesManId, int Year)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var Indirect = IndirectDatas.Where(x => x.SalesManId == SalesManId && x.Year == Year );
                foreach (var item in Indirect)
                {
                    IndirectVolumenAll.Add(new IndirectData()
                    {
                        DystrCustomer = item.DystrCustomer,
                        Volumen = item.Volumen,
                        Quarter = item.Quarter

                    });
                }
            }

            return IndirectVolumenAll;
        }

        public void SaveChanges()
        {

            _DbContext.SaveChanges();

        }
    }
}
