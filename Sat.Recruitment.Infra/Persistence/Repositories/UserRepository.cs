using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }


        public async Task<bool> AlreadyExist(User entity)
        {
            var alreadyExist = await entities.AsNoTracking().FirstOrDefaultAsync(x =>
                x.Email == entity.Email
                || x.Phone == entity.Phone
                || (x.Name == entity.Name && x.Address == entity.Address));

            return alreadyExist is not null;
        }

    }
}
