using B3.Application.Mapper;
using B3.Infrastructure.AutoMapper;
using B3.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace B3.Application
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
            _serviceCollection.AddTransient<IObjectMapper, AutoMapperObjectMapper>();
            _serviceCollection.AddSingleton(AutoMapperBootstrap.GetConfiguration());
        }
    }
}