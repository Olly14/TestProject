using Web.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Data.Infrastructure.Repository.IAppUsersRepositiry;

namespace Web.Api.Data.Infrastructure.Persistence.AppUsersRepo
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<AppUser>> FindAppUsersWithOrderAsync()
        {
            return await Task.Run(() => BdContext.AppUsers.Include(au => au.Orders).OrderBy(au => au.UserName).ToListAsync());
        }

        public async Task<AppUser> FindAppUserWithOrderAsync(string id)
        {
            return await Task.Run(() => BdContext.AppUsers.Include(au => au.Orders).Where(au=>au.AppUserId == id).FirstOrDefaultAsync());
        }
    }
}
