using AppSalesMan2.Database;
using AppSalesMan2.Database.Entity;
using AppSalesMan2.Database.Repository;
using AppSalesMan2.Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AppSalesMan2.Repository
{
    
    public  class CustomerModelRepository
    {
        CustomerModelMapper Mapper = new CustomerModelMapper();
        ObservableCollection<CustomerData> CustomerDatas = new ObservableCollection<CustomerData>();
        ObservableCollection<CustomerModel> CustomerModels = new ObservableCollection<CustomerModel>();
        ObservableCollection<CustomerModel> SearchLists = new ObservableCollection<CustomerModel>();
        CustomerDataRepository Repository = new CustomerDataRepository();
        List<CustomerModel> SearchResult;
        public ObservableCollection<CustomerModel> GetSalesManCustomerList(int Id)
        {
            
            CustomerDatas = Repository.GetSalesManCustomerList(Id);
            foreach (var item in CustomerDatas)
            {
                CustomerModels.Add(Mapper.Map(item));
            }

            return CustomerModels;
        }
        public ObservableCollection<CustomerModel> SearchList(string name, string SAP,string IFA, string PostCode, string City, string Industry, string Logistic)
        {
            if(SearchResult !=null)
            SearchResult.Clear();
            SearchLists.Clear();
            CustomerDatas.Clear();
            CustomerDatas = Repository.GetAllCustomerList();
            foreach (var item in CustomerDatas)
            {
                SearchLists.Add(Mapper.Map(item));
            }
            if (name != "")
            {
              SearchResult = SearchLists.Where(x => x.Name == name).ToList();
              SearchLists.Clear();
              foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (SAP != "")
            {
                SearchResult = SearchLists.Where(x => x.SAP == Int32.Parse(SAP)).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (IFA != "")
            {
                SearchResult = SearchLists.Where(x => x.IFA == Int32.Parse(IFA)).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (PostCode != "")
            {
                SearchResult = SearchLists.Where(x => x.Postcode == PostCode).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (City != "")
            {
                SearchResult = SearchLists.Where(x => x.City == City).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (Industry != "")
            {
                SearchResult = SearchLists.Where(x => x.Industry == Industry).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }
            if (Logistic != "")
            {
                SearchResult = SearchLists.Where(x => x.Logistic == Logistic).ToList();
                SearchLists.Clear();
                foreach (var item in SearchResult)
                {
                    SearchLists.Add(item);
                }
                SearchResult.Clear();
            }

            return SearchLists;
        }
        public void ChangeRequest(CustomerModel customerModel)
        {

            Repository.ChangeRequest(Mapper.Map(customerModel));
        }
        
    }
}
