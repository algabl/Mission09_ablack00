using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission09_ablack00.Models;

namespace Mission09_ablack00.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository Repo { get; set; }

        public CategoryViewComponent(IBookstoreRepository temp)
        {
            Repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData?.Values["category"];
            var categories = Repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}