using System;

namespace CrowfoundingHn.Common.Bootstrapper
{
    public interface IBootstrapperTask<in TContainer>
    {
        Action<TContainer> Task { get; }
    }
}