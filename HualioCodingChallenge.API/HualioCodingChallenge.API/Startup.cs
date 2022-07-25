using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;

using System;
using HualioCodingChallenge.Core.Validators;
using HualioCodingChallenge.Repository;
using HualioCodingChallenge.Repository.UnitOfWork;
using HualioCodingChallenge.Helpers.Helper;
using HualioCodingChallenge.Core.Domain;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using HualioCodingChallenge.Core.ViewModels;
using HualioCodingChallenge.Domain.Products;

namespace HualioCodingChallenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDirectoryBrowser();
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });


            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));


            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductsDomain, ProductsDomain>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            string connectionString = this.Configuration.GetSection("ConnectionStrings:HualioCodingChallengeConnectionString").Value;
            bool validateIssuer = Convert.ToBoolean(Configuration.GetSection("JwtSettings:ValidateIssuer").Value);
            bool validateAudience = Convert.ToBoolean(Configuration.GetSection("JwtSettings:ValidateAudience").Value);
            bool validateLifetime = Convert.ToBoolean(Configuration.GetSection("JwtSettings:ValidateLifetime").Value);
            bool validateIssuerSigningKey = Convert.ToBoolean(Configuration.GetSection("JwtSettings:ValidateIssuerSigningKey").Value);
            string validIssuer = this.Configuration.GetSection("JwtSettings:ValidIssuer").Value;
            string validAudience = this.Configuration.GetSection("JwtSettings:ValidAudience").Value;
            string issuerSigningKey = this.Configuration.GetSection("JwtSettings:JwtSecret").Value;

            services.AddDbContext<HualioCodingChallengeDBContext>(opt => opt.UseSqlServer(connectionString));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = validateIssuer,
                    ValidateAudience = validateAudience,
                    ValidateLifetime = validateLifetime,
                    ValidateIssuerSigningKey = validateIssuerSigningKey,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
                };
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
