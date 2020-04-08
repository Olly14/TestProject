using Web.Api.Data.Infrastructure.Repository;
using Web.Api.Domain;



namespace Web.Api.Data.Infrastructure.Persistence
{
    public class UnitOfWorkAppUserRepo : UnitOfWork<AppUser>, IUnitOfWork<AppUser>
    {
        public UnitOfWorkAppUserRepo(BdContext bdContext) : base(bdContext)
        {

        }
    }
}
