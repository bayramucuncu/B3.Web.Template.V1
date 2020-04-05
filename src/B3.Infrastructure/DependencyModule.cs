using B3.Infrastructure.DependencyInjection;
using B3.Infrastructure.Hash;
using B3.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace B3.Infrastructure
{
    public class DependencyModule: IDependencyModule
    {
        private readonly IServiceCollection _serviceCollection;

        public DependencyModule(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void LoadDependencies()
        {
            _serviceCollection.AddTransient<IApplicationSettings, ApplicationSettings>();
            _serviceCollection.AddTransient<IHashService, Md5HashService>();

        }
    }
}