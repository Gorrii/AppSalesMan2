using AppSalesMan2.Database.Entity;
using AppSalesMan2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Mapper
{
    public class CustomerVolumenMapper
    {
        private IMapper _Mapper;
        public CustomerVolumenMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomersVolumenData, CustomerVolumenModel>().ReverseMap();

            }).CreateMapper();
        }
        public CustomerVolumenModel Map(CustomersVolumenData CusotmerVolumen)
        {
            return _Mapper.Map<CustomerVolumenModel>(CusotmerVolumen);
        }
        public CustomersVolumenData Map(CustomerVolumenModel CusotmerVolumen)
        {
            return _Mapper.Map<CustomersVolumenData>(CusotmerVolumen);
        }
    }
}
