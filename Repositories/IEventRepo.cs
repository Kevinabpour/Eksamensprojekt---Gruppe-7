using Microsoft.Extensions.Logging;
using Eksamensprojekt___Gruppe_7.Models;
namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public interface IEventRepo
    {
        List<Event> GetAll();
        void Add(Event test);
        void Remove(int name);
    }
}
