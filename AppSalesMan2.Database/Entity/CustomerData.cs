using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AppSalesMan2.Database.Entity
{
    public class CustomerData
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public int SAP { get; set; }
        public int IFA { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public int SalesManID { get; set; }
        public string Industry { get; set; }
        public string Logistic { get; set; }
        public bool RequestForChange { get; set; }

    }
}
