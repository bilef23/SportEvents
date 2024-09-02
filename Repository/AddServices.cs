using Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repository.Seed;

namespace Repository;

public static class AddServices
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>().Value.DefaultConnection;
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IDbSeeder, DbSeeder>();
    }
}