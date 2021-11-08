using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.MediatorBehaviours
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ITransactionable
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IDataContext _dbContext;
        private readonly INotifierService _notifierService;
        private IDistributedCache _cache;

        public TransactionBehavior(ILogger<TransactionBehavior<TRequest, TResponse>> logger,
                                   IDataContext dbContext,
                                   IDistributedCache cache,
                                   INotifierService notifierService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _cache = cache;
            _notifierService = notifierService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;
            try
            {
                await _dbContext.RetryOnExceptionAsync(async () =>
                {
                    _logger.LogInformation($"Begin transaction: {typeof(TRequest).Name}.");
                    await _dbContext.BeginTransactionAsync(cancellationToken);

                    response = await next();

                    await _dbContext.CommitTransactionAsync(cancellationToken);

                    _notifierService.Notify(typeof(TRequest).Name + " Completed succesfully");

                    _cache.Remove("");

                    _logger.LogInformation($"End transaction: {typeof(TRequest).Name}.");
                });
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}.");
                await _dbContext.RollbackTransactionAsync(cancellationToken);
                _logger.LogError(e.Message, e.StackTrace);

                throw;
            }

            return response;
        }
    }
}
