using AppSalesMan2.Database.Repository;
using AppSalesMan2.Mapper;
using AppSalesMan2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSalesMan2.Repository
{
    public class WonOppModelRepository
    {
        double CumulatedVolumen;
        readonly WonOppDataRepository dataRepository = new WonOppDataRepository();
        readonly WonOppMapper Mapper = new WonOppMapper();

        public ObservableCollection<WonOppModel> GetWonOppList(int SalesManId)
        {
            ObservableCollection<WonOppModel> WonOppList = new ObservableCollection<WonOppModel>();
            var WonOppData = dataRepository.GetWonOppData(SalesManId);
            foreach (var item in WonOppData)
            {
                WonOppList.Add(Mapper.Map(item));
            }


            return WonOppList;
        }
        public double GetCumulatedVolumen(int ID)
        {
            CumulatedVolumen = dataRepository.GetCumulatedVolumen(ID);
            return CumulatedVolumen;
        }
    }
}
