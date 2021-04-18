using AutoMapper;
using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.Entities.Models.RegisterModel;
using DigitArc.ProductModule.WebApiService.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.Core.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(source => source.Price));

        }
    }
}
