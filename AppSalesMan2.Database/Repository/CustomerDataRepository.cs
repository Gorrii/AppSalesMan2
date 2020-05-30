using AppSalesMan2.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Database.Repository
{
    
    public class CustomerDataRepository
    {
      
        
        readonly ObservableCollection<CustomerData> CustomerList = new ObservableCollection<CustomerData>();
        readonly ObservableCollection<CustomerData> AllCustomers = new ObservableCollection<CustomerData>();
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<CustomerData> CustomerDatas => _DbContext.CustomerDatas;
        public CustomerDataRepository()
        {
            
        }
       
        public ObservableCollection<CustomerData> GetSalesManCustomerList(int SalesManId)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                
                var customerDatas = CustomerDatas.Where(x => x.SalesManID == SalesManId);
                foreach (var item in customerDatas)
                {
                    CustomerList.Add(new CustomerData()
                    {
                        CompanyID = item.CompanyID,
                        Name = item.Name,
                        SAP = item.SAP,
                        Industry = item.Industry,
                        Logistic = item.Logistic,
                        IFA = item.IFA,
                        Postcode = item.Postcode,
                        City = item.City,
                        SalesManID = item.SalesManID,
                        RequestForChange = item.RequestForChange


                    });
                }
            }

            return CustomerList;
        }
        public ObservableCollection<CustomerData> GetAllCustomerList()
        {
            using (var db = new AppSalesMan2DbContext())
            {

                var AllCustomer = CustomerDatas;
                foreach (var item in AllCustomer)
                {
                    AllCustomers.Add(new CustomerData()
                    {
                        CompanyID = item.CompanyID,
                        Name = item.Name,
                        SAP = item.SAP,
                        Industry = item.Industry,
                        Logistic = item.Logistic,
                        IFA = item.IFA,
                        Postcode = item.Postcode,
                        City = item.City,
                        SalesManID = item.SalesManID,
                        RequestForChange = item.RequestForChange


                    });
                }
            }

            return AllCustomers;
        }


        public void ChangeRequest(CustomerData customerData)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var Request = CustomerDatas.Where(x => x.CompanyID == customerData.CompanyID).FirstOrDefault();
                Request.RequestForChange = true;

                SaveChanges();
            }
        }
        
        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
