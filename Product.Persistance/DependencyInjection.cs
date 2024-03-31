using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Interfaces;

namespace TestTask.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<TestTaskDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITestTaskDbContext>(provider =>
                provider.GetService<TestTaskDbContext>());
            return services;
        }
    }
}
