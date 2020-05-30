using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSalesMan2.Models
{
    public class ChangeRequestModel
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public int SalesManId { get; set; }
        public string Parameter { get; set; }
        public string NewParameter { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public ObservableCollection<ChangeRequestModel> RequestList { get; set; }
    }
}
