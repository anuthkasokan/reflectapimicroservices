using System;
using System.Linq;
using CognizantReflect.Api.Helpers;
using CognizantReflect.Api.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReflectionEmailService.Adapter;
using ReflectionEmailService.Adapter.Interfaces;
using ReflectionEmailService.BusinessLogic;
using ReflectionEmailService.BusinessLogic.Interface;
using ReflectionEmailService.Helpers;
using ReflectionEmailService.Helpers.Interface;
using ReflectionEmailService.Models;

namespace ReflectionEmailService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(
                options =>
                {
                    options.Audience = "api://dc794641-4320-41ab-92f0-56e027b2695b";//clientId
                    options.Authority = "https://login.microsoftonline.com/cea101fb-acfa-4ba2-90e9-5a83909297e7";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };

                });
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200","https://cognizantreflectapp.com", "http://cognizantreflectapp.com")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials();
                                  });
            });

            var mongoDbSettings = services.FirstOrDefault(descripter => descripter.ServiceType == typeof(IConfigureOptions<envSettings>));
            if (mongoDbSettings == null)
                ConfigureEnvSettings(services);

            services.AddControllers();

            services.AddScoped<IEmail, Email>();
            services.AddScoped<IEmailServiceBusinessLogic, EmailServiceBusinessLogic>();
            services.AddScoped<IEmailTemplateAdapter, EmailTemplateAdapter>();
            services.AddScoped<IMongoClientHelper<EmailTemplate>, MongoClientHelper<EmailTemplate>>();
            services.AddScoped<IMongoClientHelper<EmailRequest>, MongoClientHelper<EmailRequest>>();
            services.AddScoped<IHttpClientWrapper<UserDetails>, HttpClientWrapper<UserDetails>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureEnvSettings(IServiceCollection services)
        {
            string connectionString = "mongodb://reflectcosmosdb:SXlfTBJhjykzt5iik220lP0rD8mFVUgL2XaW6Re83j0uE23FtS3gOM9kze6X9VrjLggjOuHU7v2WCnp1dQqsug==@reflectcosmosdb.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@reflectcosmosdb@";
            var dbSettings = new envSettings();
            Configuration.GetSection("envSettings").Bind(dbSettings);
            services.Configure<envSettings>(options =>
            {
                options.ConnectionString = connectionString;
                options.DbName = "reflectiontoolsecdb" ?? Environment.GetEnvironmentVariable("DBNAME");
                options.emailTemplateCollection = "emailtemplate" ?? Environment.GetEnvironmentVariable("EMAILTEMPLATECOLLECTION");
                options.emailRequestCollection = "emailrequest" ?? Environment.GetEnvironmentVariable("EMAILTEMPLATECOLLECTION");
                options.mailCredUsername = "hamidnk77@gmail.com";// ?? Environment.GetEnvironmentVariable("EMAILTEMPLATECOLLECTION");
                options.mailCredPassword = "Hamid123@";// ?? Environment.GetEnvironmentVariable("EMAILTEMPLATECOLLECTION");
                options.smtpHost = "smtp.gmail.com";
                options.smtpPort = 587;
                options.userapibaseurl = "http://40.124.104.149/users/userdetails/";

            });
        }
    }
}
