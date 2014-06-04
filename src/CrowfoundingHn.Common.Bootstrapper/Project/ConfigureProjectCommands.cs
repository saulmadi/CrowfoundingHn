using System;

using Autofac;

using CrowfoundingHn.Projects.Application.CommandHandlers;
using CrowfoundingHn.Projects.Application.Commands;

namespace CrowfoundingHn.Common.Bootstrapper.Project
{
    public class ConfigureProjectCommands:IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task
        {
            get
            {
                return builder =>
                    {
                        var projectAssembly = typeof(CreateProject).Assembly;

                        builder.RegisterAssemblyTypes(projectAssembly)
                               .Where(type => typeof(CreateProjectCreator).Namespace.EndsWith(type.Namespace))
                               .AsImplementedInterfaces();

                    };
            }
        }
    }
}