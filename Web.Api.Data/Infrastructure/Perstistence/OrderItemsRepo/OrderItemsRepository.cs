using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Data.Infrastructure.Repository.IOrderItemsRepository;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Persistence.OrderItemsRepo
{
    public class OrderItemsRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<OrderItem>> FindOrderItemsWithOrdersAndProductsAsync()
        {
            return await Task.Run(() => BdContext.OrderItems.Include(oi => oi.Order).Include(oi => oi.Product).OrderBy(oi => oi.CreatedDate));
        }
    }
}
