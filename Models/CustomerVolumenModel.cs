using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace AppSalesMan2.Models
{
   public class CustomerVolumenModel: INotifyPropertyChanged
    {
        public int VolumenID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public double OI { get; set; }
        public double Rev { get; set; }
        public double BV { get; set; }
        public double OIBY19 { get; set; }
        public double RevBY19 { get; set; }
        public double BVBY19 { get; set; }
        public double OIBY20 { get; set; }
        public double RevBY20 { get; set; }
        public double BVBY20 { get; set; }
        public int SalesManId { get; set; }
        private ObservableCollection<CustomerVolumenModel> _CustomerVolumen;
        public ObservableCollection<CustomerVolumenModel> CustomerVolumen
        {
            get
            {
                return _CustomerVolumen;
            }
            set
            {
                _CustomerVolumen = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomerVolumen"));
            }


        }
        private ObservableCollection<CustomerVolumenModel> _VolumenPerMonth;
        public ObservableCollection<CustomerVolumenModel> VolumenPerMonth
        {
            get
            {
                return _VolumenPerMonth;
            }
            set
            {
                _VolumenPerMonth = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VolumenPerMonth"));
            }


        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
