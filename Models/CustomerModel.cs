using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppSalesMan2
{
    public class CustomerModel : INotifyPropertyChanged
    {
        
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public int SAP { get; set; }
        public int IFA { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Industry { get; set; }
        public string Logistic { get; set; }
        public int SalesManID { get; set; }
        public bool RequestForChange { get; set; }

        private ObservableCollection<CustomerModel> _CustomerList;
        public ObservableCollection<CustomerModel> CustomerList
        {
            get
            {
                return _CustomerList;
            }
            set
            {
                _CustomerList = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomerList"));
            }


        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
