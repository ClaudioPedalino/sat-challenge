using System;

namespace Sat.Recruitment.Application.Interfaces
{
    /// <summary>
    /// This interfaces is to flag any query-request-object we want to be cached
    /// </summary>
    public interface ICacheable
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
