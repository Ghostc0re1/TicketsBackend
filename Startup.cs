using TicketsBackend.Services;

namespace TicketsBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ... other services

            services.AddScoped<CategoryService>();
        }
    }
}
