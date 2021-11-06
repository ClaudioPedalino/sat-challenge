using Sat.Recruitment.Domain;

namespace Sat.Recruitment.Application.AppConfig
{
    public class AppConfig
    {
        public DatabaseConfig DatabaseConfig { get; init; }
        public UserTypePercentage UserTypePercentage { get; init; }
    }

    public class DatabaseConfig
    {
        public string SatDb { get; init; }
    }

    
}
