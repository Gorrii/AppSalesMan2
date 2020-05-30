using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSalesMan2.Database.Entity
{
    public class CustomersVolumenData
    {
        [Key]
        public int VolumenID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public int SalesManId{get; set;}
        public double OI { get; set; }
        public double Rev { get; set; }
        public double BV { get; set; }

    }
}
