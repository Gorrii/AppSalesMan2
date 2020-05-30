using AppSalesMan2.Database.Entity;
using AppSalesMan2.Database.Repository;
using AppSalesMan2.Mapper;
using AppSalesMan2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace AppSalesMan2.Repository
{
   public class CustomerVolumenModelRepository
    {

        CustomerModelRepository CustomerRepository = new CustomerModelRepository();
        List<int> CustomerList = new List<int>();
        ObservableCollection<CustomersVolumenData> CustomerVolumenData = new ObservableCollection<CustomersVolumenData>();
        ObservableCollection<CustomerVolumenModel> customerVolumenModelsPerMonth = new ObservableCollection<CustomerVolumenModel>();
        ObservableCollection<CustomerVolumenModel> customerVolumenModelsPerYear = new ObservableCollection<CustomerVolumenModel>();
        ObservableCollection<CustomerVolumenModel> SortedVolumen = new ObservableCollection<CustomerVolumenModel>();
        
        readonly CustomerVolumenMapper Mapper = new CustomerVolumenMapper();
        readonly CustomerVolumenDataRepository Repository = new CustomerVolumenDataRepository();
        public ObservableCollection<CustomerVolumenModel> GetVolumenList(int Id)
        {
            
            ObservableCollection<CustomerVolumenModel> customerVolumenModels = new ObservableCollection<CustomerVolumenModel>();
            CustomerVolumenData = Repository.GetCustomerVolumen(Id);
            foreach (var item in CustomerVolumenData)
            {
                customerVolumenModels.Add(Mapper.Map(item));
            }

            return customerVolumenModels;
        }

        public ObservableCollection<CustomerVolumenModel> GetSortedVolumenList(int Id)
        {
            //Pobranie wszystkich volumenow
            ObservableCollection<CustomerVolumenModel> customerVolumenModels = GetVolumenList(Id);
            //Pobranie wszystkich Customerow
            foreach (var Customer in CustomerRepository.GetSalesManCustomerList(Id))
            {
                CustomerList.Add(Customer.CompanyID);
            }
            foreach (var CustomerID in CustomerList)
            {
                CustomerVolumenModel Model = new CustomerVolumenModel();
                foreach (var volumen in customerVolumenModels)
                {
                    if (CustomerID == volumen.CustomerId)
                    {
                        Model.CustomerId = volumen.CustomerId;
                        Model.CustomerName = volumen.CustomerName;
                        Model.BV += volumen.BV;
                        Model.OI += volumen.OI;
                        Model.Rev += volumen.Rev;
                    
                    if (volumen.Year == 2019)
                    {
                        Model.BVBY19 += volumen.BV;
                        Model.OIBY19 += volumen.OI;
                        Model.RevBY19 += volumen.Rev;
                    }
                    if (volumen.Year == 2020)
                    {
                        Model.BVBY20 += volumen.BV;
                        Model.OIBY20 += volumen.OI;
                        Model.RevBY20 += volumen.Rev;
                    }
                    }
                }
                if (Model.CustomerName != null)
                {
                    SortedVolumen.Add(new CustomerVolumenModel
                    {
                        CustomerId = Model.CustomerId,
                        CustomerName = Model.CustomerName,
                        OI = Model.OI,
                        BV = Model.BV,
                        Rev = Model.Rev,
                        OIBY19 = Model.OIBY19,
                        OIBY20 = Model.OIBY20,
                        BVBY19 = Model.BVBY19,
                        BVBY20 = Model.BVBY20,
                        RevBY19 = Model.RevBY19,
                        RevBY20 = Model.RevBY20
                        
                    });
                }
            }
            return SortedVolumen;
        }
        public ObservableCollection<CustomerVolumenModel> GetSelectedCustomerVolumen(int SalesManID, int CompanyID)
        {
            ObservableCollection<CustomerVolumenModel> VolumenPerMonth = new ObservableCollection<CustomerVolumenModel>();
            customerVolumenModelsPerMonth = GetVolumenList(SalesManID);
            
            for (int i = 1; i < 13; i++)
            {

                CustomerVolumenModel Model = new CustomerVolumenModel();
                foreach (var item in customerVolumenModelsPerMonth)
                {
                    if (item.CustomerId == CompanyID)
                    { 
                    if (item.Month == i)
                    {


                        if (item.Year == 2019)
                        {
                            Model.Month = item.Month;
                            Model.BVBY19 = item.BV;
                            Model.OIBY19 = item.OI;
                            Model.RevBY19 = item.Rev;
                        }
                        if (item.Year == 2020)
                        {
                            Model.Month = item.Month;
                            Model.BVBY20 = item.BV;
                            Model.OIBY20 = item.OI;
                            Model.RevBY20 = item.Rev;
                        }
                    }
                }
                }
                VolumenPerMonth.Add(new CustomerVolumenModel
                {
                    
                    
                    Month = i,
                    OIBY19 = Model.OIBY19,
                    OIBY20 = Model.OIBY20,
                    BVBY19 = Model.BVBY19,
                    BVBY20 = Model.BVBY20,
                    RevBY19 = Model.RevBY19,
                    RevBY20 = Model.RevBY20

                });

            }
            return VolumenPerMonth;
        }
        public ObservableCollection<CustomerVolumenModel> GetAllSelectedBY(int SalesManID, int Year)
        {
            ObservableCollection<CustomerVolumenModel> VolumenPerYear = new ObservableCollection<CustomerVolumenModel>();
            customerVolumenModelsPerYear = GetVolumenList(SalesManID);

            for (int i = 1; i < 13; i++)
            {

                CustomerVolumenModel Model = new CustomerVolumenModel();
                foreach (var item in customerVolumenModelsPerYear)
                {
                        if (item.Month == i)
                        {

                            if (item.Year == 2020)
                            {
                                Model.Month = item.Month;
                                Model.BVBY20 += item.BV;
                                Model.OIBY20 += item.OI;
                                Model.RevBY20 += item.Rev;
                            }
                        }
                 }
                
            VolumenPerYear.Add(new CustomerVolumenModel
                {


                    Month = i,
                    OIBY19 = Model.OIBY19,
                    OIBY20 = Model.OIBY20,
                    BVBY19 = Model.BVBY19,
                    BVBY20 = Model.BVBY20,
                    RevBY19 = Model.RevBY19,
                    RevBY20 = Model.RevBY20

                });

            }
            return VolumenPerYear;

            
        }
    }
}
