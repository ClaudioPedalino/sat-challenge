using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task<bool> Delete(Guid id);
    }
}
