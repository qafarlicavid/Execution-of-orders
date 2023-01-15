using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly DataContext _dataContext;

        public ShopController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("cart", Name = "client-shop-cart")]
        public IActionResult Cart()
        {
            return View();
        }

        [HttpGet("checkout", Name = "client-shop-checkout")]
        public async Task<IActionResult> CheckoutAsync()
        {
            return View();
        }
    }
}
