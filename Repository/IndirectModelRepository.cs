using AppSalesMan2.Database.Repository;
using AppSalesMan2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppSalesMan2.Repository
{
  public class IndirectModelRepository
    {
        double Q1SUM;
        double Q2SUM;
        double Q3SUM;
        double Q4SUM;
        double AllSUM;
        IndirectModel indirectModel = new IndirectModel();
        IndirectDataRepository IndirectRepository = new IndirectDataRepository();
        ObservableCollection<IndirectModel> indirectModels = new ObservableCollection<IndirectModel>();

        public ObservableCollection<IndirectModel> GetIndirectList(int SalesManID , int Year , int Quater)
        {
            var DataIndirect = IndirectRepository.GetIndirectYearAndQuater(SalesManID, Year, Quater);
            foreach (var item in DataIndirect)
            {
                indirectModels.Add( new IndirectModel()
                {
                    DystrCustomer = item.DystrCustomer,
                    Volumen = item.Volumen
                });
            }


            return indirectModels;
        }
        public IndirectModel GetQuaterSum(int SalesManId , int Year)
        {
            var DataIndirect = IndirectRepository.GetAllInDirect(SalesManId, Year);
            foreach (var item in DataIndirect)
            {
                AllSUM += item.Volumen;
                if (item.Quarter == 1)
                {
                    
                    Q1SUM += item.Volumen;
                }
                if (item.Quarter == 2)
                {
                    Q2SUM += item.Volumen;
                }
                if (item.Quarter == 3)
                {
                    Q3SUM += item.Volumen;
                }
                if (item.Quarter == 4)
                {
                    Q4SUM += item.Volumen;
                }
               
            }
            indirectModel.SumAll = AllSUM;
            indirectModel.SumQ1 = Q1SUM;
            indirectModel.SumQ2 = Q2SUM;
            indirectModel.SumQ3 = Q3SUM;
            indirectModel.SumQ4 = Q4SUM;

            return indirectModel;
        }

    }
}
