using System;

using Autofac;
using Autofac.Core;

using CrowfoundingHn.Projects.Data;
using CrowfoundingHn.Projects.Domain;

namespace CrowfoundingHn.Common.Bootstrapper
{
    public class ConfigureProjectDependencies:IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task
        {
            get
            {
                return builder => builder.Register(
                    context =>
                        {
                            var collectionFactory =
                                context.Resolve<IMongoCollectionFactory>(new NamedParameter("key", "ProjectDb"));
                            return new ProjectRepository(collectionFactory.CreateCollection("Projects"));
                        }).As<IProjectRepository>();
            }
        }
    }
}