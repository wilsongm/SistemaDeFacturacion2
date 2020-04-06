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

            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();

            CreateMap<Entry, EntryDto>().ReverseMap();
            CreateMap<EntryDto, Entry>().ReverseMap();

            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();

            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<BillingDto, Billing>().ReverseMap();


        }
    }
}
