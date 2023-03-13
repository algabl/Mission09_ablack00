using Microsoft.AspNetCore.Mvc;
using Mission09_ablack00.Models;

namespace Mission09_ablack00.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository Repo { get; set; }
        private Basket Basket { get; set; }

        public OrderController(IOrderRepository temp, Basket b)
        {
            Repo = temp;
            Basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (Basket.Items.Count == 0)
            {
                ModelState.AddModelError("","Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = Basket.Items.ToArray();
                Repo.SaveOrder(order);
                Basket.ClearBasket();
                return RedirectToPage("/OrderCompleted");
            }

            return View();
        }
    }
}