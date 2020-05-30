using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSalesMan2.Database.Entity
{
     public class PlansData
    {
        [Key]
        public int PlanID { get; set; }
        public int SalesManId { get; set; }
        public double PlanValue { get; set; }
    }
}
