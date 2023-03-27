using EcommerceStore.DbContexts;
using EcommerceStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStore.Services;

public class EcommerceStoreRepository : IEcommerceStoreRepository
{
    private readonly EcommerceStoreContext _context;

    private static IEnumerable<Product> Products = new List<Product>();

    public EcommerceStoreRepository(EcommerceStoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        // return await _context.Products.OrderBy(p => p.Id).ToListAsync();
        return await _context.Products
            .Include(p => p.Categories)
            .Include((p => p.Images))
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(string? brand)
    {
        if (string.IsNullOrEmpty(brand))
        {
            return await GetProductsAsync();
        }

        var collection = _context.Products
            .Include(p => p.Categories)
            .Include(p => p.Images)
            as IQueryable<Product>;
        
        if (!string.IsNullOrWhiteSpace(brand))
        {
            brand = brand.Trim();
            collection = collection.Where(p => p.Brand == brand);
        }
        return await collection.OrderBy(p => p.Id).ToListAsync();

    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Categories)
            .Include((p => p.Images))
            .Where(p => p.Id == productId).FirstOrDefaultAsync();
    }

    public void AddProductAsync(Product product)
    {
        _context.Products.Add(product);
    }

    public Task<bool> ProductExistsAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Image>> GetImagesForProductAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<Image?> GetImageForProductAsync(int productId, int imageId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategoriesForProductAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetCategoryForProductAsync(int productId, int imageId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}