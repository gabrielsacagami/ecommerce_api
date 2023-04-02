using AutoMapper;
using EcommerceStore.Entities;
using EcommerceStore.Models;
using EcommerceStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStore.Controllers;

[ApiController]
[Route("api/products")]

public class ProductsController : ControllerBase
{
    private readonly IEcommerceStoreRepository _ecommerceStoreRepository;
    private readonly IMapper _mapper;

    public ProductsController(IEcommerceStoreRepository ecommerceStoreRepository, IMapper mapper)
    {
        _ecommerceStoreRepository = ecommerceStoreRepository ??
                                    throw new ArgumentNullException(nameof(ecommerceStoreRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? brand)
    {
        var productEntities = await _ecommerceStoreRepository.GetProductsAsync(brand);
        
        if (!productEntities.Any())
        {
            return NotFound();
        }
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(productEntities));
    }
    
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        var productEntity = await _ecommerceStoreRepository.GetProductAsync(productId);

        if (productEntity == null)
        {
            return NotFound();
        }
        
        return Ok(productEntity);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        var finalProduct = product;
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _ecommerceStoreRepository.AddProductAsync(finalProduct);
        await _ecommerceStoreRepository.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new
            {
                productId = finalProduct.Id
            },
            finalProduct);
    }


}