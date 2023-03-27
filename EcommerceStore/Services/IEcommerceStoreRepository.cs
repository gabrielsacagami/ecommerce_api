using EcommerceStore.Entities;

namespace EcommerceStore.Services;

public interface IEcommerceStoreRepository
{
    
   Task<IEnumerable<Product>> GetProductsAsync();
   Task<IEnumerable<Product>> GetProductsAsync(string? brand);
   Task<Product?> GetProductAsync(int productId);
   void AddProductAsync(Product product);
   // Task<bool> ProductExistsAsync(int productId);
   // Task<IEnumerable<Image>> GetImagesForProductAsync(int productId);
   // Task<Image?> GetImageForProductAsync(int productId, int imageId);
   // Task<IEnumerable<Category>> GetCategoriesForProductAsync(int productId);
   // Task<Category?> GetCategoryForProductAsync(int productId, int imageId);
   Task<bool> SaveChangesAsync();
}