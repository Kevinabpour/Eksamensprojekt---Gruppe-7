using System.Collections.Generic;
using Eksamensprojekt___Gruppe_7.Models;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public interface IEventRepo
    {
        List<Event> GetAll();
        Event GetById(int id);
        void Add(Event ev);
        void Update(Event ev);
        void Remove(int id);
    }
}
