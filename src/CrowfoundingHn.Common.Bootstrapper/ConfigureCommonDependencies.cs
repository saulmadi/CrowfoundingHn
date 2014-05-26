using System;

using Autofac;

namespace CrowfoundingHn.Common.Bootstrapper
{
    public class ConfigureProjectCommands:IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task { get; private set; }
    }
    public class ConfigureCommonDependencies:IBootstrapperTask<ContainerBuilder>
    {

        public Action<ContainerBuilder> Task
        {
            get
            {
                return builder =>
                    { 
                        builder.RegisterType<AutoFacCommandDispatcher>().As<ICommandDispatcher>();
                        builder.RegisterType<AutoFacDomainEventDispatcher>().As<IDomainEvent>();
                    };
            }
     
        }
    }
}