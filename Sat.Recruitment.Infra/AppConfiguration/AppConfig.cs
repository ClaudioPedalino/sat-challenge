using System.Collections.Generic;

namespace Sat.Recruitment.Infra.AppConfiguration
{
    public class AppConfig
    {
        public DatabaseConfig DatabaseConfig { get; init; }
        public CacheSetting CacheSetting { get; init; }
        public Api Api { get; init; }
        public JwtSettings JwtSettings { get; init; }
        public IpRateLimit IpRateLimit { get; init; }
    }

    public class DatabaseConfig
    {
        public string SatDb { get; init; }
    }

    public class CacheSetting
    {
        public int SlidingExpiration { get; init; }
    }

    public class JwtSettings
    {
        public string TokenType { get; init; }
        public string Secret { get; init; }
        public ushort ValidHours { get; init; }
    }

    public class Api
    {
        public string Version { get; init; }
        public string Name { get; init; }
        public string SatApiKey { get; init; }
    }

    public class IpRateLimit
    {
        public bool EnableEndpointRateLimiting { get; set; }
        public bool StackBlockedRequests { get; set; }
        public string RealIpHeader { get; set; }
        public string ClientIdHeader { get; set; }
        public long HttpStatusCode { get; set; }
        public List<GeneralRule> GeneralRules { get; set; }
    }

    public class GeneralRule
    {
        public string Endpoint { get; set; }
        public string Period { get; set; }
        public long Limit { get; set; }
    }

}
