using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_ablack00.Models;
using Mission09_ablack00.Infrastructure;

namespace Mission09_ablack00.Pages
{
    public class Cart : PageModel
    {
        private IBookstoreRepository Repo { get; set; }

        public Cart(IBookstoreRepository temp)
        {
            Repo = temp;
        }
        
        public Basket Basket { get; set; }
        
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = Repo.Books.FirstOrDefault(x => x.BookId == bookId);
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            Basket.AddItem(b, 1);

            HttpContext.Session.SetJson("Basket", Basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}