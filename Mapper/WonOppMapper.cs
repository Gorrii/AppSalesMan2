using AppSalesMan2.Database.Entity;
using AppSalesMan2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSalesMan2.Mapper
{
    public class WonOppMapper
    {
        private IMapper _Mapper;
        public WonOppMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<WonOppData, WonOppModel>().ReverseMap();

            }).CreateMapper();
        }
        public WonOppData Map(WonOppModel WonOpp)
        {
            return _Mapper.Map<WonOppData>(WonOpp);
        }
        public WonOppModel Map(WonOppData WonOpp)
        {
            return _Mapper.Map<WonOppModel>(WonOpp);
        }
    }
}

