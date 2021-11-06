using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infra.Interfaces
{
    public interface IDataContext
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken);

        Task CommitTransactionAsync(CancellationToken cancellationToken);

        Task RollbackTransactionAsync(CancellationToken cancellationToken);

        Task RetryOnExceptionAsync(Func<Task> func);
    }
}
