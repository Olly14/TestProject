using System.Linq;
using System.Threading.Tasks;
using Web.Api.Data;
using Web.Api.Data.Infrastructure.Persistence;
using Web.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Web.Api.Domain;

namespace Web.Api.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class GenderRepository : DropDownListRepository<Gender>, IGenderRepository
    {
        public GenderRepository(BdContext bdContext) : base(bdContext)
        {
            
        }

        public async Task<Gender> FindGenderTypeByGenderTypeId(string genderId)
        {
            return await Task.Run(() => BdContext.Genders
                .Where(g => g.GenderId == genderId)
                .ToList()
                .FirstOrDefault());

        }

    }
}
