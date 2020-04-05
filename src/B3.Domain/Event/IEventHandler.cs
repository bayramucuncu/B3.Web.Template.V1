using System.Threading.Tasks;

namespace B3.Domain.Event
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent domainEvent);
    }
}