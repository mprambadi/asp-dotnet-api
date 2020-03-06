using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using FluentValidation;
using dotnet_mediatr.Domain.Entities;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Infrastructure.Persistence;
using dotnet_mediatr.Application.Infrastructures;
using dotnet_mediatr.Infrastructure.BackgroundServices.Scheduler;
using dotnet_mediatr.Infrastructure.BackgroundServices.Queue;
using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator;
using MediatR;
using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.SqlServer;
namespace dotnet_mediatr
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
            services.AddControllers();

            services.AddHangfire(configuration => configuration

                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }
            ));

            services.AddHangfireServer();

            services.AddMediatR(typeof(GetCreatorQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));
            services.AddDbContext<IBlogContext, BlogContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PosgreServer")));

            services.AddMvc()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetCreatorValidator>());

            // services.AddHostedService<DailyGreetings>();
            // services.AddHostedService<ReceiverQueue>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJob)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireDashboard();

            backgroundJob.Enqueue(() => Console.WriteLine("Task Run"));

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
