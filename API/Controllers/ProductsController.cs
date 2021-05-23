using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productRepository.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _productRepository.GetProductByIdAsync(id));
        }


        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetProductCategoriesAsync()
        {
            return Ok(await _productRepository.GetProductCategoriesAsync());
        }

        [HttpGet("productbycategory/{categoryId}")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductByCategoryAsync(int categoryId)
        {
            return Ok(await _productRepository.GetProductByCategoryAsync(categoryId));
        }

    }

}
