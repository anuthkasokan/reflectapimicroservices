using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReflectionFeedback.Api.Adapters;
using ReflectionFeedback.Api.Adapters.Interfaces;
using ReflectionFeedback.Api.BusinessLogics;
using ReflectionFeedback.Api.BusinessLogics.Interfaces;
using ReflectionFeedback.Api.Filters;
using ReflectionFeedback.Api.Helpers;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOriginsForFeedback = "_myAllowSpecificOriginsForFeedback";

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
                options.AddPolicy(MyAllowSpecificOriginsForFeedback,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://40.124.104.106", "http://40.124.104.106", "https://cognizantreflectapp.com", "http://cognizantreflectapp.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            var mongoDbSettings = services.FirstOrDefault(descripter => descripter.ServiceType == typeof(IConfigureOptions<MongoDbSettings>));
            if (mongoDbSettings == null)
                ConfigureMongoDb(services);

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ServiceFilterAttribute(typeof(InternalErrorExceptionFilter)));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);


            services.AddScoped<InternalErrorExceptionFilter>();
            services.AddScoped<IFeedbackBusinessLogics, FeedbackBusinessLogics>();
            services.AddScoped<IGetFeedbackDetailsAdapter, GetFeedbackDetailsAdapter>();
            services.AddScoped<IStoreFeedbackAdapter, StoreFeedbackAdapter>();
            services.AddScoped<IMongoClientHelper<Feedback>, MongoClientHelper<Feedback>>();
            services.AddScoped<IMongoClientHelper<FeedbackReply>, MongoClientHelper<FeedbackReply>>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOriginsForFeedback);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void ConfigureMongoDb(IServiceCollection services)
        {
            var dbSettings = new MongoDbSettings();
            Configuration.GetSection("MongoDbSettings").Bind(dbSettings);
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = dbSettings.ConnectionString ?? "mongodb://reflectcosmosdb:SXlfTBJhjykzt5iik220lP0rD8mFVUgL2XaW6Re83j0uE23FtS3gOM9kze6X9VrjLggjOuHU7v2WCnp1dQqsug==@reflectcosmosdb.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@reflectcosmosdb@";
                options.DbName = dbSettings.ConnectionString ?? "reflectiontoolsecdb";
                options.FeedbackCollection = dbSettings.ConnectionString ?? "feedback";
                options.FeedbackReplyCollection = dbSettings.ConnectionString ?? "feedback_reply";
                options.ErrorLogsCollection = dbSettings.ConnectionString ?? "errorlogs";
            });
        }
    }
}
