using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
     public class PlansDataRepository
    {
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<PlansData> PlansDatas => _DbContext.plansDatas;

        public PlansData GetSalesManPlans(int Id)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var Plans = PlansDatas.Single(x => x.SalesManId == Id);

                return Plans;
            }
        }


        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
