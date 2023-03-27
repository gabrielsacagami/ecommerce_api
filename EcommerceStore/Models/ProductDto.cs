namespace EcommerceStore.Models;

public class ProductDto
{
   public int Id { get; set; }

   public string Name { get; set; } = string.Empty;
   
   public string? Description { get; set; }
   
   public int Price { get; set; }
   
   public string? Brand { get; set; }

   public ICollection<ImageDto> Images { get; set; } = new List<ImageDto>();

   public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

}