using AppSalesMan2.Database.Entity;
using AppSalesMan2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Mapper
{
    public class ChangeRequestMapper
    {
        private IMapper _Mapper;
        public ChangeRequestMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<ChangeRequestData, ChangeRequestModel>().ReverseMap();

            }).CreateMapper();
        }
        public ChangeRequestData Map(ChangeRequestModel changeRequest)
        {
            return _Mapper.Map<ChangeRequestData>(changeRequest);
        }
        public ChangeRequestModel Map(ChangeRequestData changeRequest)
        {
            return _Mapper.Map<ChangeRequestModel>(changeRequest);
        }
    }
}

