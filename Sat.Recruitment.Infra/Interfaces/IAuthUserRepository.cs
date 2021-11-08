using Sat.Recruitment.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<IQueryable<User>> GetAll();
    }
}
