using System;
using B3.Infrastructure.Entity;
using B3.Infrastructure.Reflection;
using B3.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace B3.EntityFramework
{
    public class DatabaseContext: DbContext
    {
        private readonly IApplicationSettings _applicationSettings;

        public DatabaseContext(DbContextOptions options, IApplicationSettings applicationSettings) : base(options)
        {
            _applicationSettings = applicationSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            switch (_applicationSettings.DatabaseType)
            {
                case "pgsql":
                    optionsBuilder.UseNpgsql(_applicationSettings.ConnectionSettings, builder => builder.UseNetTopologySuite());
                    break;
                default:
                    optionsBuilder.UseSqlServer(_applicationSettings.ConnectionSettings);
                    break;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            AppDomain.CurrentDomain.FromAssembliesMatching<IEntity>("*.dll")
                .ForEach(m=>modelBuilder.Entity(m));
        }
    }
}