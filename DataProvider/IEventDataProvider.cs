using EMSwithREST.Models;

namespace EMSwithREST.DataProvider
{
    public interface IEventDataProvider
    {
        Task<IEnumerable<Event>> GetEvents();

        Task<Event> GetEvent(int eventId);

        Task AddEvent(Event evt);

        Task UpdateEvent(Event evt);

        Task DeleteEvent(int eventId);
    }
}