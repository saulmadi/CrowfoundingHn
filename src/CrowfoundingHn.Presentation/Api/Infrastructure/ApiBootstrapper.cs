using System;

using Autofac;

using CrowfoundingHn.Common.Bootstrapper;
using CrowfoundingHn.Common.Bootstrapper.Authentication;
using CrowfoundingHn.Common.Bootstrapper.Project;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public class ApiBootstrapper : Bootstrapper
    {
        public ApiBootstrapper()
        {
            AddBootstrapperTask(new ConfigureCommonDependencies());
            
            AddBootstrapperTask(new ConfigureProjectCommands());
            AddBootstrapperTask(new ConfigureProjectDependencies());

            AddBootstrapperTask(new ConfigureAuthenticationCommands());
            AddBootstrapperTask(new ConfigureAuthenticationDependencies());
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            //pipelines.OnError += (ctx, err) => HandleExceptions(err, ctx);

            pipelines.AfterRequest.AddItemToEndOfPipeline(AddCorsHeaders());

            base.RequestStartup(container, pipelines, context);
        }

        static Response HandleExceptions(Exception err, NancyContext ctx)
        {
            if (ctx.Response == null)
            {
                ctx.Response = new Response { };
                AddCorsHeaders()(ctx);
            }

            return ctx.Response;
        }

        static Action<NancyContext> AddCorsHeaders()
        {
            return x =>
                {
                    Response response = x.Response;
                    response.WithHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                    response.WithHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                    response.WithHeader("Access-Control-Max-Age", "1728000");
                    response.WithHeader("Access-Control-Allow-Origin", "*");
                };
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("App"));
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Assets"));
        }
    }
}