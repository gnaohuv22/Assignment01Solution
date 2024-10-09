using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _baseUrl = "https://localhost:7194/api/OrderAPI";

        public OrderController(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        //GET: Order
        public async Task<IActionResult> Index()
        {
            var orders = await _httpClient.GetFromJsonAsync<IEnumerable<Order>>($"{_baseUrl}/GetAllOrders");
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return View(orderDtos);
        }

        //GET: Order/Details/{id} 
        public async Task<IActionResult> Details(int id)
        {
            var order = await _httpClient.GetFromJsonAsync<Order>($"{_baseUrl}/GetOrderById/{id}");
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDto>(order);
            return View(orderDto);
        }

        //GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/AddOrder", orderDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating new order.");
            return View(orderDto);
        }

        //GET: Order/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _httpClient.GetFromJsonAsync<Order>($"{_baseUrl}/GetOrderById/{id}");
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return View(orderDto);
        }

        //POST: Order/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDto orderDto)
        {
            if (!ModelState.IsValid || id != orderDto.OrderId)
            {
                return BadRequest();
            }

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/UpdateOrder/{id}", orderDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the order.");
            return View(orderDto);
        }

        //GET: Order/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var order = await _httpClient.GetFromJsonAsync<Order>($"{_baseUrl}/GetOrderById/{id}");
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching the order.");
                return RedirectToAction(nameof(Index));
            }
        }

        //POST: Order/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/DeleteOrder/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while deleting the order.");
                var order = await _httpClient.GetFromJsonAsync<Order>($"{_baseUrl}/GetOrderById/{id}");
                return View(order);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the order.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
