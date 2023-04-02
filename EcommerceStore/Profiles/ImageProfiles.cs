using AutoMapper;

namespace EcommerceStore.Profiles;

public class ImageProfiles : Profile
{
    public ImageProfiles()
    {
        CreateMap<Entities.Image, Models.ImageDto>();
    }
    
}