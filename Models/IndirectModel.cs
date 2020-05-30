using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSalesMan2.Models
{
   public class IndirectModel
    {
        public int IndirectID { get; set; }
        public string DystrCustomer { get; set; }
        public int SalesManId { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public double Volumen { get; set; }
        public double SumQ1 { get; set; }
        public double SumQ2 { get; set; }
        public double SumQ3 { get; set; }
        public double SumQ4 { get; set; }
        public double SumAll { get; set; }
        public ObservableCollection<IndirectModel> IndirectQ1 { get; set; }
        public ObservableCollection<IndirectModel> IndirectQ2 { get; set; }
        public ObservableCollection<IndirectModel> IndirectQ3 { get; set; }
        public ObservableCollection<IndirectModel> IndirectQ4 { get; set; }

    }
}
