using System;

namespace Sat.Recruitment.Application.Interfaces
{
    public interface ICacheable
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
