using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Bi.Dto;
using SystemVenta.Model.Entities;

namespace SystemVenta.Bi.Mapper
{
     public  class SystemVentaProfile : Profile
    {
        public SystemVentaProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<Provider, ProviderDto>().ReverseMap();
            CreateMap<ProviderDto, Provider>().ReverseMap();

        }
    }
}
