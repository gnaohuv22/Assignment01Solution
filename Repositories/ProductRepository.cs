using BusinessObject;
using DataAccess;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productDAO.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productDAO.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            await _productDAO.CreateProductAsync(productDto);
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            await _productDAO.UpdateProductAsync(id, productDto);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productDAO.DeleteProductAsync(id);
        }
    }
}
