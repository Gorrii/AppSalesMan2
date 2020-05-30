using AppSalesMan2.Database.Entity;
using AppSalesMan2.Database.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Repository
{
    public class SalesMansRepository
    {
     
        private SalesMansModel _salesMansModel;
        SalesManMapper Mapper = new SalesManMapper();
        SalesManDataRepository Repository = new SalesManDataRepository();

  
        public SalesMansRepository()
        {

        }

        public SalesMansModel SalesManLogin(string _FirstName, string _LastName, string _Password)
        {

            try
            {
                _salesMansModel = Mapper.Map(Repository.GetSalesMans(_FirstName, _LastName, _Password));
            }
            catch (InvalidOperationException)
            {

                _salesMansModel = null;
            }

            return _salesMansModel;
        }

        public void UpdateData(SalesMansModel _salesMansModel)
        {
            SalesMansData NewSalesManData = new SalesMansData();
             NewSalesManData = Mapper.Map(_salesMansModel);
            Repository.UpdateData(NewSalesManData);

        }

    }
}
