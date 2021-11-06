using Sat.Recruitment.Domain.Entities;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> AlreadyExist(User entity);
    }
}
