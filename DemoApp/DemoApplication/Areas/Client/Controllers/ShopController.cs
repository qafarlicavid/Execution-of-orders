using DemoApplication.Areas.Client.ViewModels.Shop;
using DemoApplication.Database;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;

        public ShopController(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService= userService;
        }
        [HttpGet("cart", Name = "client-shop-cart")]
        public IActionResult Cart()
        {
            return View();
        }

        [HttpGet("checkout", Name = "client-shop-checkout")]
        public async Task<IActionResult> CheckoutAsync()
        {
            var model = new OrderViewModel
            {
                SumTotal = (int)_dataContext.BasketProducts.
                Where(bp => bp.Basket!.UserId == _userService.CurrentUser.Id).Sum(bp => bp.Book!.Price * bp.Quantity)
            };

            model.Models = await _dataContext.BasketProducts
                  .Where(bp => bp.Basket!.UserId == _userService.CurrentUser.Id)
                  .Select(bp =>
                      new OrderViewModel.ItemViewModel(
                          bp.Id,
                          bp.Book!.Title,
                          bp.Quantity,
                          bp.Book.Price,
                          bp.Book.Price * bp.Quantity
                          ))
                  .ToListAsync();

            return View(model);
        }
    }
}
