using System;
using System.Linq;
using System.Net;
using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Filters;
using CognizantReflect.Api.Helpers.Excel;
using CognizantReflect.Api.Helpers.Excel.Interface;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using CognizantReflect.Api.Models.CuriosityQuiz;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using CognizantReflect.Api.Models.Reports;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CognizantReflect.Api.Helpers
{
    internal class ProgramDependencyHelper :IProgramDependencyHelper
    {
        public void ScopedDependencies(IConfiguration configuration, IServiceCollection services)
        {
            var mongoDbSettings = services.FirstOrDefault(descripter => descripter.ServiceType == typeof(IConfigureOptions<MongoDbSettings>));
            if (mongoDbSettings == null)
                ConfigureMongoDb(configuration,services);

            var serviceSettings = services.FirstOrDefault(descripter => descripter.ServiceType == typeof(IConfigureOptions<ServiceSettings>));
            if (serviceSettings == null)
                ConfigureMicroServices(configuration,services);

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ServiceFilterAttribute(typeof(InternalErrorExceptionFilter)));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<InternalErrorExceptionFilter>();
            services.AddScoped<IMongoClientHelper<ErrorLogs>, MongoClientHelper<ErrorLogs>>();
            services.AddScoped<IMongoClientHelper<QuizAttempts>, MongoClientHelper<QuizAttempts>>();
            services.AddScoped<IMongoClientHelper<LearningMythsQuiz>, MongoClientHelper<LearningMythsQuiz>>();
            services.AddScoped<IReportsBusinessLogic, ReportsBusinessLogic>();
            services.AddScoped<IContinuousLearningBusinessLogic, ContinuousLearningBusinessLogic>();
            services.AddScoped<ILearningMythsBusinessLogic, LearningMythsBusinessLogic>();
            services.AddScoped<ICuriousQuizBusinessLogic, CuriousQuizBusinessLogic>();
            services.AddScoped<IDashboardBusinessLogics, DashboardBusinessLogics>();
            services.AddScoped<IStoryTellingForImpactBusinessLogic, StoryTellingForImpactBusinessLogic>();
            services.AddScoped<IGrowthMindsetQuizBusinessLogic, GrowthMindsetQuizBusinessLogic>();
            services.AddScoped<IMakingTimeForMeQuizBusinessLogic, MakingTimeForMeQuizBusinessLogic>();
            services.AddScoped<ICulturalObservationBusinessLogic, CulturalObservationBusinessLogic>();
            services.AddScoped<IProductivityZoneQuizBusinessLogic, ProductivityZoneQuizBusinessLogic>();
            services.AddScoped<IContinuousLearningAdapter, ContinuousLearningAdapter>();
            services.AddScoped<IProductivityZoneQuizAdapter, ProductivityZoneQuizAdapter>();
            services.AddScoped<ICulturalObservationAdapter, CulturalObservationAdapter>();
            services.AddScoped<IReportsAdapter, ReportsAdapter>();
            services.AddScoped<IDashboardAdapter, DashboardAdapter>();
            services.AddScoped<ICuriousQuizAdapter, CuriousQuizAdapter>();
            services.AddScoped<IStoryTellingForImpactAdapter, StoryTellingForImpactAdapter>();
            services.AddScoped<IGrowthMindsetAdapter, GrowthMindsetAdapter>();
            services.AddScoped<ILearningMythsAdapter, LearningMythsAdapter>();
            services.AddScoped<IMakingTimeForMeQuizAdapter, MakingTimeForMeQuizAdapter>();
            services.AddScoped<IMongoClientHelper<ContinuousLearningAssessmentQuiz>, MongoClientHelper<ContinuousLearningAssessmentQuiz>>();            
            services.AddScoped<IMongoClientHelper<CultureObservationToolQuiz>, MongoClientHelper<CultureObservationToolQuiz>>();
            services.AddScoped<IMongoClientHelper<MakingTimeForMeQuiz>, MongoClientHelper<MakingTimeForMeQuiz>>();
            services.AddScoped<IMongoClientHelper<ProductivityZoneQuiz>, MongoClientHelper<ProductivityZoneQuiz>>();
            services.AddScoped<IMongoClientHelper<MakingTimeForMeQuizAttempts>, MongoClientHelper<MakingTimeForMeQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<GrowthMindsetQuiz>, MongoClientHelper<GrowthMindsetQuiz>>();
            services.AddScoped<IMongoClientHelper<GrowthMindsetQuizAttempts>, MongoClientHelper<GrowthMindsetQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<StoryTellingForImpactQuiz>, MongoClientHelper<StoryTellingForImpactQuiz>>();
            services.AddScoped<IMongoClientHelper<CuriousQuiz>, MongoClientHelper<CuriousQuiz>>();
            services.AddScoped<IMongoClientHelper<CuriousQuizAttempts>, MongoClientHelper<CuriousQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<BlindSpotQuizAttempts>, MongoClientHelper<BlindSpotQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts>, MongoClientHelper<ContinuousLearningAssessmentQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<CultureObservationToolQuizAttempts>, MongoClientHelper<CultureObservationToolQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<GrowthMindsetQuizAttempts>, MongoClientHelper<GrowthMindsetQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<LearningMythsQuizAttempts>, MongoClientHelper<LearningMythsQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<MakingTimeForMeQuizAttempts>, MongoClientHelper<MakingTimeForMeQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<ProductivityZoneQuizAttempts>, MongoClientHelper<ProductivityZoneQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<ReflectionToolQuizAttempt>, MongoClientHelper<ReflectionToolQuizAttempt>>();
            services.AddScoped<IMongoClientHelper<StoryTellingForImpactQuizAttempts>, MongoClientHelper<StoryTellingForImpactQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<StoryTellingForImpactQuizAttempts>, MongoClientHelper<StoryTellingForImpactQuizAttempts>>();
            services.AddScoped<IBlindSpotBusinessLogics, BlindSpotBusinessLogics>();
            services.AddScoped<IBlindSpotAdapter, BlindSpotAdapter>();
            services.AddScoped<IMongoClientHelper<BlindSpotQuizAttempts>, MongoClientHelper<BlindSpotQuizAttempts>>();
            services.AddScoped<IMongoClientHelper<BlindSpotQuizQuestions>, MongoClientHelper<BlindSpotQuizQuestions>>();
            services.AddScoped<IMongoClientHelper<BlindSpotCoWorkerReply>, MongoClientHelper<BlindSpotCoWorkerReply>>();
            services.AddScoped<IReflectionToolBusinessLogics, ReflectionToolBusinessLogics>();
            services.AddScoped<IReflectionToolAdapter, ReflectionToolAdapter>();
            services.AddScoped<IMongoClientHelper<ReflectionTool>, MongoClientHelper<ReflectionTool>>();
            services.AddScoped<IMongoClientHelper<ReflectionToolQuizAttempt>, MongoClientHelper<ReflectionToolQuizAttempt>>();
            services.AddScoped<IServiceHelper<HttpWebRequest, BaseHttpResponse>, RestServiceHelper<BaseHttpResponse>>();
            services.AddScoped<IUserAdapter, UserAdapter>();
            services.AddScoped<IFeedbackAdapter, FeedbackAdapter>();
            services.AddScoped<ISettingsBusinessLogics, SettingsBusinessLogics>();
            services.AddScoped<ISettingsAdapter, SettingsAdapter>();
            services.AddScoped<IExcelReaderExtension, ExcelReaderExtension>();
            services
                .AddScoped<IMongoClientHelper<ContinuousLearningAssessmentQuiz>,
                    MongoClientHelper<ContinuousLearningAssessmentQuiz>>();
            services.AddScoped<IMongoClientHelper<CultureObservationToolQuiz>, MongoClientHelper<CultureObservationToolQuiz>>();
            services.AddScoped<IMongoClientHelper<LearningMythsQuiz>, MongoClientHelper<LearningMythsQuiz>>();
            services.AddScoped<IMongoClientHelper<ProductivityZoneQuiz>, MongoClientHelper<ProductivityZoneQuiz>>();

        }

        private void ConfigureMongoDb(IConfiguration configuration, IServiceCollection services)
        {
            var dbSettings = new MongoDbSettings();
            configuration.GetSection("MongoDbSettings").Bind(dbSettings);
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = dbSettings.ConnectionString ?? "mongodb://reflectcosmosdb:SXlfTBJhjykzt5iik220lP0rD8mFVUgL2XaW6Re83j0uE23FtS3gOM9kze6X9VrjLggjOuHU7v2WCnp1dQqsug==@reflectcosmosdb.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@reflectcosmosdb@";
                options.DbName = dbSettings.ConnectionString ?? "reflectiontooldb";
                options.CuriousQuizCollection = dbSettings.ConnectionString ?? "curiousquiz";
                options.CuriousQuizAttemptsCollection = dbSettings.ConnectionString ?? "curiousquiz_attempts";
                options.BlindSpotQuizCollection = dbSettings.ConnectionString ?? "blindspotquiz";
                options.BlindSpotQuizAttemptsCollection = dbSettings.ConnectionString ?? "blindspotquiz_attempts";
                options.BlindSpotQuizCoWorkerReplyCollection = dbSettings.ConnectionString ?? "blindspotquiz_cwreply";
                options.GrowthMindsetQuizCollection = dbSettings.ConnectionString ?? "growthmindsetquiz";
                options.GrowthMindsetAttemptsQuizCollection = dbSettings.ConnectionString ?? "growthmindsetquiz_attempts";
                options.MakingTimeForMeQuizCollection = dbSettings.ConnectionString ?? "makingtimeformequiz";
                options.MakingTimeForMeQuizAttemptsCollection = dbSettings.ConnectionString ?? "makingtimeformequiz_attempts";
                options.ProductivityZoneQuizCollection = dbSettings.ConnectionString ?? "productivityzonequiz";
                options.ProductivityZoneQuizAttemptsCollection = dbSettings.ConnectionString ?? "productivityzonequiz_attempts";
                options.StoryTellingForImpactQuizCollection = dbSettings.ConnectionString ?? "storytellingforimpactquiz";
                options.StoryTellingForImpactQuizAttemptsCollection = dbSettings.ConnectionString ?? "storytellingforimpactquiz_attempts";
                options.ContinuousLearningAssessmentQuizCollection = dbSettings.ConnectionString ?? "continuouslearningassessmentquiz";
                options.ContinuousLearningAssessmentQuizAttemptsCollection = dbSettings.ConnectionString ?? "continuouslearningassessmentquiz_attempts";
                options.ReflectionToolQuizCollection = dbSettings.ConnectionString ?? "reflectiontoolquiz";
                options.ReflectionToolQuizAttemptsCollection = dbSettings.ConnectionString ?? "reflectiontoolquiz_attempts";
                options.LearningMythsQuizCollection = dbSettings.ConnectionString ?? "learningmythsquiz";
                options.LearningMythsQuizAttemptsCollection = dbSettings.ConnectionString ?? "learningmythsquiz_attempts";
                options.CultureObservationToolQuizCollection = dbSettings.ConnectionString ?? "cultureobservationtoolquiz";
                options.CultureObservationToolQuizAttemptsCollection = dbSettings.ConnectionString ?? "cultureobservationtoolquiz_attempts";
                options.CultureObservationToolScoringCollection = dbSettings.ConnectionString ?? "cultureobservationtoolquiz_scoring";
                options.ErrorLogsCollection = dbSettings.ConnectionString ?? "errorlogs";
                options.quizDetailsCollection = dbSettings.quizDetailsCollection ?? "quizdetails";
            });
        }

        private void ConfigureMicroServices(IConfiguration configuration, IServiceCollection services)
        {
            var serviceSettings = new ServiceSettings();
            configuration.GetSection("ServiceSettings").Bind(serviceSettings);
            services.Configure<ServiceSettings>(options =>
            {
                options.UserServiceUrl = serviceSettings.UserServiceUrl ?? Environment.GetEnvironmentVariable("REFLECTUSER_SERVICE_HOST");
                options.FeedbackServiceUrl = serviceSettings.FeedbackServiceUrl ?? Environment.GetEnvironmentVariable("REFLECTFEEDBACK_SERVICE_HOST");
                options.EmailServiceUrl = serviceSettings.EmailServiceUrl ?? Environment.GetEnvironmentVariable("EMAIL_SERVICE_HOST");
            });
        }

    }
}
