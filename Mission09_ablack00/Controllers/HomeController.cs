using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission09_ablack00.Models;
using Mission09_ablack00.Models.ViewModels;

namespace Mission09_ablack00.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository Repo;
        public HomeController(IBookstoreRepository temp)
        {
            Repo = temp;
        }
        
        public IActionResult Index(string category, int pageNum)
        {
            int pageSize = 10;

            var viewModel = new BooksViewModel
            {
                Books = Repo.Books
                    .Where(b => b.Category == category || category == null)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        category == null
                            ? Repo.Books.Count()
                            : Repo.Books.Count(x => x.Category == category),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(viewModel);
        }
    }
}