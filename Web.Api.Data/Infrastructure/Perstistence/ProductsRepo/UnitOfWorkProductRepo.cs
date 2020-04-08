

using Web.Api.Data.Infrastructure.Repository;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Persistence.ProductsRepo
{
    public class UnitOfWorkProductRepo : UnitOfWork<Product>, IUnitOfWork<Product>
    {
        public UnitOfWorkProductRepo(BdContext bdContext) : base(bdContext)
        {

        }
    }
}
