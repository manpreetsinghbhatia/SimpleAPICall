using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel=SimpleAPICall.ViewModels;
using DataModel= DataAccessLib.Enitity;
namespace SimpleAPICall.mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DataModel.Order, ViewModel.Order>().ReverseMap();
            CreateMap<DataModel.Product, ViewModel.Product>().ReverseMap();
            CreateMap<DataModel.OrderDetail, ViewModel.OrderDetail>().ReverseMap();
            CreateMap<DataModel.ShippingInfo, ViewModel.ShippingInfo>().ReverseMap();
            CreateMap<DataModel.ProductDetail, ViewModel.ProductDetail>().ReverseMap();
        }
    }
}
