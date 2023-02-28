using System.Linq;

namespace Mission09_ablack00.Models
{
    public class EfBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext Context { get; set; }

        public EfBookstoreRepository(BookstoreContext temp)
        {
            Context = temp;
        }

        public IQueryable<Book> Books => Context.Books;
    }
}