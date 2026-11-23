using AutoMapper;
using p48_lessons_asp.DTO.Category;
using p48_lessons_asp.DTO.Product;

namespace p48_lessons_asp.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Data.Entity.Product, ProductDto>()
    .ForMember(dest => dest.CategoryName,
        opt => opt.MapFrom(src => src.Category != null
            ? src.Category.Title
            : string.Empty))
    .ForMember(dest => dest.ImageUrl,
        opt => opt.MapFrom(src => src.ProductImages == null
            ? null
            : src.ProductImages
                .OrderBy(img => img.Order)
                .ThenBy(img => img.CreatedAt)
                .Select(img => img.Url)
                .FirstOrDefault()));
    CreateMap<Data.Entity.ProductImage, ProductImageDto>();
    }
}
