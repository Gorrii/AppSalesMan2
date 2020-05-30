using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSalesMan2.Database.Entity
{
    public class IndirectData
    {
        [Key]
        public int IndirectID {get; set; }
        public string DystrCustomer { get; set; }
        public int SalesManId { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public double Volumen { get; set; }
}
}
