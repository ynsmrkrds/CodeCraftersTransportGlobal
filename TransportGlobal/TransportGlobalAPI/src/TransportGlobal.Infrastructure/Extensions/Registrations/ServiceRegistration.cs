using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;
using TransportGlobal.Domain.Repositories;
using TransportGlobal.Infrastructure.Context;
using TransportGlobal.Infrastructure.Repositories;

namespace TransportGlobal.Infrastructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TransportGlobalDB")!;

            services.AddDbContext<TransportGlobalDBContext>(opt =>
            {
                opt.UseSqlServer(connectionString, asm =>
                {
                    asm.MigrationsAssembly(Assembly.GetAssembly(typeof(TransportGlobalDBContext))?.GetName().Name);
                });
            });

            services.Scan(scan =>
            {
                scan.FromAssembliesOf(typeof(Repository<>))
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }
    }
}
