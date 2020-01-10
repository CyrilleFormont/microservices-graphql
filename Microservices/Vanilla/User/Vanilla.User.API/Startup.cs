
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using GraphQL.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using MicroserviceCommunicator;
using Vanilla.User.API.SchemaDefinition;
using Vanilla.User.API.SchemaDefinition.UserDefinition;
using Vanilla.User.API.SchemaDefinition.UserDefinition.InputTypes;
using Vanilla.User.API.SchemaDefinition.UserDefinition.Types;

namespace Vanilla.User.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            #region D.I.Registration
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            
            services.AddTransient<RegisterUserInputType>();
            services.AddTransient<UserType>();
            services.AddTransient<UserMutations>();
            services.AddTransient<UserQueries>();
            services.AddTransient<Mutations>();
            services.AddTransient<Queries>();
           
            services.AddTransient<IMessageBrokerSender>(provider => new MessageBrokerSender().WithArn("ARN").DryRun(true));
            #endregion D.I.Registration

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema, MainSchema>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseGraphiQl();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
