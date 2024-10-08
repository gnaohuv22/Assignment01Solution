using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _baseUrl = "https://localhost:7194/api/ProductAPI";

        public ProductController(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        //GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"{_baseUrl}/GetAllProducts");
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return View(productDtos);
        }

        //GET: Product/Details/{id} 
        public async Task<IActionResult> Details(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/GetProductById/{id}");
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return View(productDto);
        }

        //GET: Product/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await GetCategories();
            return View();
        }

        //POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/AddProduct", productDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating new product.");
            return View(productDto);
        }

        //GET: Product/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/GetProductById/{id}");
            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);
            ViewBag.Categories = await GetCategories();
            return View(productDto);
        }

        //POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid || id != productDto.ProductId)
            {
                return BadRequest();
            }

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/UpdateProduct/{id}", productDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the product.");
            return View(productDto);
        }

        //GET: Product/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/GetProductById/{id}");
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the product.");
                return RedirectToAction(nameof(Index));
            }
        }

        //POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/DeleteProduct/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while deleting the product.");
                var product = await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/GetProductById/{id}");
                return View(product);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the product.");
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task<IEnumerable<Category>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("https://localhost:7194/api/CategoryAPI/GetAllCategories");
        }
    }
}
