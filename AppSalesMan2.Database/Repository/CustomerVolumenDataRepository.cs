using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
   public class CustomerVolumenDataRepository
    {
        
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<CustomersVolumenData> CustomerDatas => _DbContext.customersVolumenDatas;


        public ObservableCollection<CustomersVolumenData> GetCustomerVolumen(int SalesManId)
        {
            ObservableCollection<CustomersVolumenData> VolumenData = new ObservableCollection<CustomersVolumenData>();
            using (var db = new AppSalesMan2DbContext())
            {
                var CustomerVolumen = CustomerDatas.Where(x => x.SalesManId == SalesManId);
                foreach (var item in CustomerVolumen)
                {
                    VolumenData.Add(new CustomersVolumenData()
                    {
                        Year = item.Year,
                        Month = item.Month,
                       // SAP = item.SAP,
                         CustomerId = item.CustomerId,
                        CustomerName = item.CustomerName,
                        BV = item.BV,
                        OI = item.OI,
                        Rev = item.Rev,
                    });
                }
            }

            return VolumenData;
        }
        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
