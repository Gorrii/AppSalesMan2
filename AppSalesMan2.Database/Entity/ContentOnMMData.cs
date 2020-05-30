using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSalesMan2.Database.Entity
{
    public class ContentOnMMData
    {
        [Key]
        public int ContentId { get; set; }
        public int SalesManId { get; set; }
        public string HighLights { get; set; }
        public string LowLights { get; set; }
        public string CriticalIssue { get; set; }
        public string GeneralTopic { get; set; }




    }
}
