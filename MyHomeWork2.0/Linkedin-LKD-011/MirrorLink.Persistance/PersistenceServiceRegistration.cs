using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Persistence.Repositories;

namespace MirrorLink.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MirrorLinkDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("MirrorLinkDbConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}