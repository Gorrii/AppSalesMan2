using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AppSalesMan2.Database.Entity;
using AppSalesMan2.Database.Repository;
using AppSalesMan2.Mapper;
using AppSalesMan2.Models;

namespace AppSalesMan2.Repository
{

    
    class ChangeRequestModelRepository
    {

        ChangeRequestModel ChangeRequestModel = new ChangeRequestModel();
        ObservableCollection<ChangeRequestData> ChangeRequestDatas = new ObservableCollection<ChangeRequestData>();
        ObservableCollection<ChangeRequestModel> changeRequestModels = new ObservableCollection<ChangeRequestModel>();
        readonly ChangeRequestMapper Mapper = new ChangeRequestMapper();
        readonly ChangeRequestDataRepository Repository = new ChangeRequestDataRepository();

        public void AddRequest(ChangeRequestModel requestModel)
        {
            Repository.AddRequest(Mapper.Map(requestModel));

           
        }
        public ObservableCollection<ChangeRequestModel> GetRequestList(int Id)
        {
            ChangeRequestDatas = Repository.GetRequstList(Id);
            foreach (var item in ChangeRequestDatas)
            {
                changeRequestModels.Add(Mapper.Map(item));
            }

            return changeRequestModels;
        }
    }
}
