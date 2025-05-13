using Eksamensprojekt___Gruppe_7.Models;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public interface IAnimalRepo
    {
            void Remove(int animal);
            void Add(Animal animal);
            List<Animal> GetAll();
            Animal Get(string name);

     
    }
}
