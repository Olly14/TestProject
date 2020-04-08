using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Data.Infrastructure.Repository.IProductRepository;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Persistence.ProductsRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BdContext bdContext) : base(bdContext)
        {
            
        }

        public async Task<IEnumerable<Product>> FindPoductsWithOrderItemsAsync()
        {
            return await Task.Run(() => BdContext.Products.Include(p => p.OrderItems).OrderBy(p => p.Name));
        }
    }
}
