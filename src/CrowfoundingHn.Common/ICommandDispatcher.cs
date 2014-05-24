

namespace CrowfoundingHn.Common
{
    public interface ICommandDispatcher
    {
        void Dispatch(ICommand command);
    }
}