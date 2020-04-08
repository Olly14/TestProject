using Web.Api.Domain;
using System.Threading.Tasks;




namespace Web.Api.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IGenderRepository : IDropDownListRepository<Gender>
    {
        Task<Gender> FindGenderTypeByGenderTypeId(string genderId);
    }
}
