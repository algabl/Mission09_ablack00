using System.Linq;

namespace Mission09_ablack00.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}