using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;
using Microsoft.Extensions.Logging;

namespace Eksamensprojekt___Gruppe_7.Service
{
    public class EventService
        {
            IEventRepo _eventRepo;
            public EventService(IEventRepo memberrepo)
            {
                _eventRepo = memberrepo;
            }
            public void Add(Event vent)
            {

                _eventRepo.Add(vent);
            }
            public void Remove(int name)
            {
                _eventRepo.Remove(name);
            }
            public List<Event> GetAll()
            {
                return _eventRepo.GetAll();

            }
            public void Update(Event updatedEvent)
            {

            }

        }
}
