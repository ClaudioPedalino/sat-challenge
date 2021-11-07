using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Infra.AppConfiguration;
using Serilog;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.MediatorBehaviours
{
    public class CacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheable
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly CacheSetting _cacheSetting;

        public CacheBehaviour(IDistributedCache cache, ILogger logger, IOptionsMonitor<CacheSetting> cacheSetting)
        {
            _cache = cache;
            _logger = logger;
            _cacheSetting = cacheSetting.CurrentValue;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            if (request.BypassCache) return await next();
            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();
                var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromHours(_cacheSetting.SlidingExpiration) : request.SlidingExpiration;
                var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await _cache.SetAsync(request.CacheKey, serializedData, options, cancellationToken);
                return response;
            }
            var cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                _logger.Information($"Fetched from Cache -> '{request.CacheKey}'.");
            }
            else
            {
                response = await GetResponseAndAddToCache();
                _logger.Information($"Added to Cache -> '{request.CacheKey}'.");
            }
            return response;
        }
    }
}
