using TicketsBackend.Services;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using TicketsBackend.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TicketsBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CategoryService>();
            services.AddDbContext<TestDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDatabase"));

            // JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://login.microsoftonline.com/Your_Tenant_Id";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://sts.windows.net/c6d685ee-a0cf-40c4-a046-2c64cbeded7b/",
                        ValidateAudience = true,
                        ValidAudience = "f61d1422-3444-4400-b12e-9735ea437f5c",
                        ValidateLifetime = true
                    };
                });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ... existing configuration ...

            // Use authentication
            app.UseAuthentication();

            // ... other middleware ...
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
