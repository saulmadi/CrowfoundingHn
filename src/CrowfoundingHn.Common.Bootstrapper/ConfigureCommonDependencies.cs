using System;

using Autofac;

namespace CrowfoundingHn.Common.Bootstrapper
{
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
                        builder.RegisterType<MongoCollectionFactory>().As<IMongoCollectionFactory>();
                    };
            }
     
        }
    }
}