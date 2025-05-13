using Eksamensprojekt___Gruppe_7.Models;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public class AnimalRepo : IAnimalRepo
    {
        List<Animal> _animals;

        public List<Animal> GetAll()
        {
            return _animals;
        }
        public void Add(Animal animal)
        {
            _animals.Add(animal);
        }
        public Animal Get(string name)
        {
            foreach (Animal animal in _animals)
            {
                if (name == animal.Name)
                {
                    return animal;
                }
            }
            return null;
        }



        public void Remove(int member)
        {
            _animals.RemoveAt(member);
        }

        public AnimalRepo()
        {
            _animals = new List<Animal>();
            _animals.Add(new Animal(
                name: "Trofast",
                chipnumber: "4572",
                text: "HaderEfternavn@hotmail.com",
                picture: "Dyr1 (Trofast).png"));
            _animals.Add(new Animal(
                name: "Misser",
                chipnumber: "4571",
                text: "HaderEfternavn@hotmail.com",
                picture: "Dyr2 (Misser).png"));
            _animals.Add(new Animal("Vovse", "FieProfil.png", "44528579", "BoatMomma@hotmail.com"));

        }
    }
}
