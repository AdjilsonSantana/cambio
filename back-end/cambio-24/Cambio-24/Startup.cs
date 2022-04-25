using Cambio_24.CrossCutting.Configuration;
using Cambio_24.CrossCutting.Configuration.Constants;
using Cambio_24.CrossCutting.DependencyInjection;
using Cambio_24.Data.Configuration;
using Cambio_24.Data.Context;
using Cambio_24.Security.Config;
using Cambio_24.WebApi.Middleware;
using Cambio_24.WebApi.Sesson;
using Cambio_24.WebApi.Sesson.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Cambio_24
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);


            
            if(EnvironmentConfiguration.ConnectionString == EnvironmentDatabaseConnectionString.Postgre )
            {
                
                var environment = EnvironmentConfiguration.Database == EnvironmentDatabaseEnum.Prod ? DatabaseConfig.DbConnectionPostgre : DatabaseConfig.TestDbConnectionPostgre;
                services.AddDbContext<Cambio24Context>(options => options.UseNpgsql(environment));
            }
            else
            {
                var environment = EnvironmentConfiguration.Database == EnvironmentDatabaseEnum.Prod ? DatabaseConfig.DbConnection : DatabaseConfig.TestDbConnection;
                services.AddDbContext<Cambio24Context>(options => options.UseSqlServer(environment));
            }






            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(7);
                options.Cookie.MaxAge = TimeSpan.FromSeconds(7);
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddSingleton<ISessionHandler, SessionHandler>();
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddControllers();
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "cambio_24",
                    Version = "v1"
                });
            });
            //services.AddControllers();
            //services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "cambio_24 v1");
                if (EnvironmentConfiguration.Environment == EnvironmentEnum.Prod)
                {
                    c.RoutePrefix = string.Empty;
                }

            });

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }); 
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //use Jwt middleware
            app.UseMiddleware<JwtMiddleware>();
            //Enable user session
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            


            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

        }

    }
}
