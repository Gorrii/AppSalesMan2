using AppSalesMan2.Database.Entity;
using AutoMapper;

namespace AppSalesMan2
{
    public class SalesManMapper
    {
        private IMapper _Mapper;
        public SalesManMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<SalesMansData, SalesMansModel>().ReverseMap();
                
            }).CreateMapper();
        }
        public SalesMansModel Map(SalesMansData salesMansData)
        {
            return _Mapper.Map<SalesMansModel>(salesMansData);
        }
        public SalesMansData Map(SalesMansModel salesMansData)
        {
            return _Mapper.Map<SalesMansData>(salesMansData);
        }

    }
}
