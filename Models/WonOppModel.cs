using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSalesMan2.Models
{
    public class WonOppModel
    {
        public int WonOppId { get; set; }
        public int SalesManId { get; set; }
        public string WonOppName { get; set; }
        public string WonOppEndCustomer { get; set; }
        public string EstimatedOIDate { get; set; }
        public double WonOppVolumen { get; set; }
        public bool Accepted { get; set; }
        public ObservableCollection<WonOppModel> WonOppList { get; set; }
    }
}
