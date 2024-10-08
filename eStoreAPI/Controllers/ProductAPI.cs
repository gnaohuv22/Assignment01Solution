using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPI : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductAPI(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        //GET: api/Product/GetAllProducts
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        //GET: api/Product/GetProductById/{id}
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        //POST: api/Product/AddProduct
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(ProductDto productDto)
        {
            await _productRepository.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductId }, productDto); // Assuming ProductDto has an Id property
        }

        //PUT: api/Product/UpdateProduct/{id}
        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, ProductDto productDto)
        {
            await _productRepository.UpdateProductAsync(id, productDto);
            return NoContent();
        }

        //DELETE: api/Product/DeleteProduct/{id}
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
