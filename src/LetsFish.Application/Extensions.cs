using LetsFish.Application.Core.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LetsFish.Application;

static public class Extensions
{
    static public IServiceCollection AddLetsFishApplication(this IServiceCollection services, string ConnectionString)
    {
        services.AddDbContext<LetsFishContext>(options => options.UseSqlServer(ConnectionString));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
