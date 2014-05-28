using Autofac;

namespace CrowfoundingHn.Common
{
    public class AutoFacCommandDispatcher : ICommandDispatcher 
    {
        readonly ILifetimeScope _lifetimeScope;

        public AutoFacCommandDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public void Dispatch(ICommand command)
        {
            var typeOfCommanad = command.GetType();
            var typeOfService = typeof(ICommandHandler<>).MakeGenericType(typeOfCommanad);

            dynamic handler = _lifetimeScope.Resolve(typeOfService);

            handler.Handle((dynamic)command);

        }
    }
}