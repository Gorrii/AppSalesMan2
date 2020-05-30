using AppSalesMan2.Database.Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AppSalesMan2.Database.Repository
{
   
   public class SalesManDataRepository
    {
        readonly AppSalesMan2DbContext _DbContext = new AppSalesMan2DbContext();
        private DbSet<SalesMansData> SalesMansDatas => _DbContext.SalesManDatas;

        public SalesManDataRepository()
        {

        }
        public void UpdateData(SalesMansData salesMansData)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var FoundSalesMan = SalesMansDatas.Where(x => x.SalesManID == salesMansData.SalesManID).FirstOrDefault();

                if (FoundSalesMan == null)
                {
                    return;
                }
                #region Mapowanie na SalesManData
                FoundSalesMan.FirstName = salesMansData.FirstName;
                FoundSalesMan.LastName = salesMansData.LastName;
                FoundSalesMan.Email = salesMansData.Email;
                FoundSalesMan.Department = salesMansData.Department;
                FoundSalesMan.Menager = salesMansData.Menager;
                FoundSalesMan.Phonenumber = salesMansData.Phonenumber;
                FoundSalesMan.Password = salesMansData.Password;
                #endregion
                SaveChanges();
            }
        }

        public SalesMansData GetSalesMans(string FirstName, string LastName, string Password)
        {
            using (var db = new AppSalesMan2DbContext())
            {
                var salesman = SalesMansDatas.Single(x => x.FirstName == FirstName & x.LastName == LastName & x.Password == Password);
            
            return salesman;
            }
        }


         public void SaveChanges()
         {
            _DbContext.SaveChanges();
         }
    }
}
