using System;

using Autofac;

using CrowfoundingHn.Common.Bootstrapper;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public class ConfigureWebDependencies : IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task
        {
            get
            {
                return contanier =>
                    {
                        contanier.RegisterType<ApiUserMapper>().As<IUserMapper>();
                    };
            }
        }
    }
}