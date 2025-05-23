// Repositories/AnimalRepo.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Eksamensprojekt___Gruppe_7.Models;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public class AnimalRepo : IAnimalRepo
    {
        private const string FileName = "animals.json";
        private readonly string _path;
        private List<Animal> _animals;

        public AnimalRepo()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", FileName);
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path));
                File.WriteAllText(_path, "[]");
            }
            var json = File.ReadAllText(_path);
            _animals = JsonSerializer.Deserialize<List<Animal>>(json) ?? new List<Animal>();
        }

        private void SaveChanges()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_animals, options);
            File.WriteAllText(_path, json);
        }

        public List<Animal> GetAll() => _animals;

        public Animal GetById(int id) => _animals.FirstOrDefault(a => a.Id == id);

        public void Add(Animal animal)
        {
            animal.Id = _animals.Any() ? _animals.Max(a => a.Id) + 1 : 1;
            _animals.Add(animal);
            SaveChanges();
        }

        public void Update(Animal animal)
        {
            var existing = GetById(animal.Id);
            if (existing != null)
            {
                existing.Name = animal.Name;
                existing.Size = animal.Size;
                existing.ChipNumber = animal.ChipNumber;
                existing.Race = animal.Race;
                existing.Characteristics = animal.Characteristics;
                existing.Picture = animal.Picture;
                existing.Avaliability = animal.Avaliability;
                existing.Defect = animal.Defect;
                SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _animals.Remove(existing);
                SaveChanges();
            }
        }
    }
}
