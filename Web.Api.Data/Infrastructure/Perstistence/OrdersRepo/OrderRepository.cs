using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Data.Infrastructure.Repository.IOrdersRepository;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Persistence.OrdersRepo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<Order>> FindOrdersWithOrderItemsAsync()
        {
            return await Task.Run(() => BdContext.Orders.Include(o => o.OrderItems).OrderBy(o => o.CreatedDate));
        }
    }
}
