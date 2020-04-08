using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Repository.IOrdersRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FindOrdersWithOrderItemsAsync();
    }
}
