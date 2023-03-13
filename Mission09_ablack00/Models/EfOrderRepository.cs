using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission09_ablack00.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private BookstoreContext context;

        public EfOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(x => x.Lines)
            .ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}