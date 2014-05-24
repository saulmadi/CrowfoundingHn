using System;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public interface IBootstrapperTask<in TContainer>
    {
        Action<TContainer> Task { get; }
    }
}