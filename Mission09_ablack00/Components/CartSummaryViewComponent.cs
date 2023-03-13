using Microsoft.AspNetCore.Mvc;
using Mission09_ablack00.Models;

namespace Mission09_ablack00.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public CartSummaryViewComponent(Basket temp)
        {
            basket = temp;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}