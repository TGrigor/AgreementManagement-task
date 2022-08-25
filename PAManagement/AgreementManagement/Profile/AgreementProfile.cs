using AgreementManagement.Data.Entities;
using AgreementManagement.Models;
using AutoMapper;

namespace AgreementManagement.Profiles
{
    public class AgreementProfile: Profile
    {
        public AgreementProfile()
        {
            CreateMap<Agreement, AgreementModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.IdentityUser.UserName))
                .ForMember(dest => dest.ProductGroupCode, opt => opt.MapFrom(src => src.ProductGroup.GroupCode))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.Product.ProductNumber))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(src => src.NewPrice));
        }
    }
}
