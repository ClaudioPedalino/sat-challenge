using Sat.Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<IQueryable<User>> GetAll();
    }
}
