using B3.Infrastructure.DependencyInjection;
using B3.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace B3.EntityFramework
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
            _serviceCollection.AddDbContext<DatabaseContext>();
            _serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}