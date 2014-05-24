
namespace CrowfoundingHn.Common
{
    public interface IDomainEvent
    {
        void Raise(IEvent @event);
    }
}