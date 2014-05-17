﻿using System.Collections.Generic;

using Autofac;

using Nancy.Bootstrappers.Autofac;

namespace CrowfoundingHn.Presentation.App.Infrastructure
{
    public abstract class Bootstrapper : AutofacNancyBootstrapper
    {
        readonly List<IBootstrapperTask<ContainerBuilder>> _tasks;

        protected Bootstrapper()
        {
            _tasks = new List<IBootstrapperTask<ContainerBuilder>>
                         {
                            
                         };
        }

        protected void AddBootstrapperTask(IBootstrapperTask<ContainerBuilder> bootstrapper)
        {
            _tasks.Add(bootstrapper);
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();
            _tasks.ForEach(task => task.Task.Invoke(builder));
            builder.Update(existingContainer.ComponentRegistry);
            base.ConfigureApplicationContainer(existingContainer);
        }
    }
}