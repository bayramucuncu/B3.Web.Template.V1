using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace B3.Infrastructure.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfiguration _configuration;

        private static string SectionName => "ApplicationSettings";

        public ApplicationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionSettings => _configuration.GetConnectionString("DefaultConnection");

        public string DatabaseType => _configuration.GetSection(SectionName)[nameof(DatabaseType)]
            .ToLower(CultureInfo.InvariantCulture);

        public int DefaultPageSize =>
            int.TryParse(_configuration.GetSection(SectionName)[nameof(DefaultPageSize)], out var dataCount)
                ? dataCount
                : 20;
    }
}