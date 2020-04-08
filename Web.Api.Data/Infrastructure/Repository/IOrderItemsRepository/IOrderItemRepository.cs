using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Repository.IOrderItemsRepository
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> FindOrderItemsWithOrdersAndProductsAsync();
    }
}
