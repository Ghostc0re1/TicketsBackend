using TicketsBackend.Services;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using TicketsBackend.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TicketsBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CategoryService>();
            services.AddDbContext<TestDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDatabase"));

            // Other services
        }
        public class TestDbContext : DbContext
        {
            public TestDbContext(DbContextOptions<TestDbContext> options)
                : base(options)
            {
            }

            public DbSet<Ticket> Tickets { get; set; }
        }
    }
}
