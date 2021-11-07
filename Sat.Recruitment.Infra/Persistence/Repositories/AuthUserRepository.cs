using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Persistence.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly DataContext _dataContext;

        public AuthUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IQueryable<User>> GetAll()
            => Task.FromResult(_dataContext.Users.AsNoTracking());
    }
}
