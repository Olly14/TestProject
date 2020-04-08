using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Repository.IProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> FindPoductsWithOrderItemsAsync();
    }
}
