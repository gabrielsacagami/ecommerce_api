using AutoMapper;

namespace EcommerceStore.Profiles;

public class CategoryProfiles : Profile
{
    public CategoryProfiles()
    {
        CreateMap<Entities.Category, Models.CategoryDto>();
    }
}