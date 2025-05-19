using Eksamensprojekt___Gruppe_7.Models;
//by Kevin
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
                size: 75,
                chipnumber: "4572",
                race: "Schæfer",
                characteristics: "Hund, Sort/brun, flade ører, tam",
                picture: "Dyr1 (Trofast).png"));
            _animals.Add(new Animal(
                name: "Misser",
                size: 34,
                chipnumber: "4571",
                race: "Perser",
                characteristics: "Kat, stribet pels, tam",
                picture: "Dyr2 (Misser).png"));
            _animals.Add(new Animal(
                name: "Trofast",
                size: 58,
                chipnumber: "4572",
                race: "Puddel",
                characteristics: "Hund, hvid pels, tam",
                picture: "Dyr1 (Trofast).png"));

        }
    }
}
