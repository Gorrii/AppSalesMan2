using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
    public class ChangeRequestDataRepository
    {
        readonly ObservableCollection<ChangeRequestData> RequestList = new ObservableCollection<ChangeRequestData>();
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<ChangeRequestData> changeRequests => _DbContext.ChangeRequestDatas;

        public void AddRequest(ChangeRequestData Request)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                changeRequests.Add(Request);
                SaveChanges();
            }
        }

        public ObservableCollection<ChangeRequestData> GetRequstList(int SalesManId)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var List = changeRequests.Where(x => x.SalesManId == SalesManId);
                foreach (var item in List)
                {
                    RequestList.Add(new ChangeRequestData()
                    {
                        CompanyID = item.CompanyID,
                        Parameter = item.Parameter,
                        NewParameter = item.NewParameter,
                        Status = item.Status

                    });
                }
            }

            return RequestList;
        }



        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
