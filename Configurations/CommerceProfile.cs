using AutoMapper;
using API.Entities;
using API.DTOs.ProductType;
using API.DTOs.Product;
using API.DTOs.Category;

namespace API.Configurations;

public class CommerceProfile : Profile
{
    public CommerceProfile()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryReadDto>().ReverseMap();
        CreateMap<Category, CategoryDetailDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        CreateMap<ProductType, ProductTypeCreateDto>().ReverseMap();
        CreateMap<ProductType, ProductTypeReadDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductType, ProductTypeDetailDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<ProductType, ProductTypeUpdateDto>().ReverseMap();

        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.ProductType.Category.Name));
        CreateMap<Product, ProductUpdateDto>().ReverseMap();


    }
}