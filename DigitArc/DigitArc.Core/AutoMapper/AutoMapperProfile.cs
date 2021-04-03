using AutoMapper;
using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.Entities.Models.RegisterModel;
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
        }
    }
}
