using System;

namespace CrowfoundingHn.Presentation.App.Infrastructure
{
    public interface IBootstrapperTask<in TContainer>
    {
        Action<TContainer> Task { get; }
    }
}