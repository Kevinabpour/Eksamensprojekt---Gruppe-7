using Eksamensprojekt___Gruppe_7.Models;
using Microsoft.Extensions.Logging;
// by Kevin
namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public class EventRepo : IEventRepo
    {
        List<Event> _events;

        public EventRepo()
        {
            _events = new List<Event>();

        }
        public List<Event> GetAll()
        {
            return _events;
        }
        public void Add(Event test)
        {
            _events.Add(test);
        }
        public void Remove(int name)
        {
            _events.RemoveAt(name);
        }



    }
}
