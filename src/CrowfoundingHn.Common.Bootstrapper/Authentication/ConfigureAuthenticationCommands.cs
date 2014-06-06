using System;

using Autofac;

using CrowfoundingHn.Common.Authentication.CommandHandlers;
using CrowfoundingHn.Common.Authentication.Commands;

namespace CrowfoundingHn.Common.Bootstrapper.Authentication
{
    public class ConfigureAuthenticationCommands : IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task
        {
            get
            {
                return builder =>
                    {
                        var projectAssembly = typeof(CreateUser).Assembly;

                        builder.RegisterAssemblyTypes(projectAssembly)
                               .Where(type => typeof(UserCreator).Namespace.EndsWith(type.Namespace))
                               .AsImplementedInterfaces();
                    };
            }
        }
    }
}