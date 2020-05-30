using AppSalesMan2.Database.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Mapper
{
    class CustomerModelMapper
    {
        private IMapper _Mapper;
        private IMapper _InternalMapper;
        public CustomerModelMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerData, CustomerModel>().ReverseMap();

            }).CreateMapper();
            _InternalMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerModel, CustomerModel>().ReverseMap();

            }).CreateMapper();
        }
       
     
        public CustomerModel Map(CustomerData customerData)
        {
            return _Mapper.Map<CustomerModel>(customerData);
        }
        public CustomerData Map(CustomerModel customerData)
        {
            return _Mapper.Map<CustomerData>(customerData);
        }
        public CustomerModel Mapp(CustomerModel customerData)
        {
            return _InternalMapper.Map<CustomerModel>(customerData);
        }
    }
}
