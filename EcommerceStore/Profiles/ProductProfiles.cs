using AutoMapper;

namespace EcommerceStore.Profiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<Entities.Product, Models.CategoryDto>();
        CreateMap<Entities.Product, Models.ImageDto>();
    }
}