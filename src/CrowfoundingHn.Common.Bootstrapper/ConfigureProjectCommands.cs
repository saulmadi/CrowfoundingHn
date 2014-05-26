using System;

using Autofac;

namespace CrowfoundingHn.Common.Bootstrapper
{
    public class ConfigureProjectCommands:IBootstrapperTask<ContainerBuilder>
    {
        public Action<ContainerBuilder> Task { get; private set; }
    }
}