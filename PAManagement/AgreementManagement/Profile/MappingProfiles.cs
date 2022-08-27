using AgreementManagement.Data.Entities;
using AgreementManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgreementManagement.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Agreement, AgreementModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.IdentityUser.UserName))
                .ForMember(dest => dest.ProductGroupCode, opt => opt.MapFrom(src => src.ProductGroup.GroupCode))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.Product.ProductNumber))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(src => src.NewPrice));

            CreateMap<Agreement, AgreementEditModel>().ReverseMap();
            CreateMap<Agreement, AgreementDeleteModel>();
            
            CreateMap<Product, KeyValueModel<string>>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ProductNumber));

            CreateMap<ProductGroup, KeyValueModel<string>>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.GroupCode));

            CreateMap<SelectListItem, KeyValueModel<string>>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Value))
               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Text)).ReverseMap();

            CreateMap<AgreementCreateModel, Agreement>();
        }
    }
}
