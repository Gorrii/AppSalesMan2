using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSalesMan2.Database.Entity
{
    public class ChangeRequestData
    {
        [Key]
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public int SalesManId { get; set; }
        public string Parameter { get; set; }
        public string NewParameter { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
