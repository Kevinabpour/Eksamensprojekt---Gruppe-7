using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;

namespace Eksamensprojekt___Gruppe_7.Service
{
    public class AnimalService
    {
        IAnimalRepo _animalRepo;

        public AnimalService(IAnimalRepo animalrepo)
        {
            _animalRepo = animalrepo;
        }
        public void Add(Animal animal)
        {

            _animalRepo.Add(animal);
        }
        public void Remove(int name)
        {
            _animalRepo.Remove(name);
        }
        public List<Animal> GetAll()
        {
            return _animalRepo.GetAll();
        }
        public void Update(Event updatedAnimal)
        {

        }
        public Animal Get(string name)
        {
            return _animalRepo.Get(name);
        }
    }
}

