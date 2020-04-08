using Web.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Data.Infrastructure.Repository.IAppUsersRepositiry
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> FindAppUsersWithOrderAsync();

        Task<AppUser> FindAppUserWithOrderAsync(string id);
    }
}
