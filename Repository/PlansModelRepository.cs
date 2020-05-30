using AppSalesMan2.Database.Repository;
using AppSalesMan2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Repository
{
   public class PlansModelRepository
    {
        PlansDataRepository DataRepository = new PlansDataRepository();
        PlansModel PlanModel = new PlansModel();


        public double GetPlans(int Id)
        {
            var PlansData = DataRepository.GetSalesManPlans(Id);
            PlanModel.PlanValue = PlansData.PlanValue;


            return PlanModel.PlanValue;
        }
    }
}
