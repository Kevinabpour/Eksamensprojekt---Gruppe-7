using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Eksamensprojekt___Gruppe_7.Models;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public class EventRepo : IEventRepo
    {
        private const string FileName = "events.json";
        private readonly string _path;
        private List<Event> _events;

        public EventRepo()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", FileName);
            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path));
                File.WriteAllText(_path, "[]");
            }
            var json = File.ReadAllText(_path);
            _events = JsonSerializer.Deserialize<List<Event>>(json) ?? new List<Event>();
        }

        private void SaveChanges()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_path, JsonSerializer.Serialize(_events, options));
        }

        public List<Event> GetAll() => _events;
        public Event GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public void Add(Event ev)
        {
            ev.Id = _events.Any() ? _events.Max(x => x.Id) + 1 : 1;
            _events.Add(ev);
            SaveChanges();
        }

        public void Update(Event ev)
        {
            var existing = GetById(ev.Id);
            if (existing == null) return;
            existing.Name = ev.Name;
            existing.Description = ev.Description;
            existing.Date = ev.Date;
            SaveChanges();
        }

        public void Remove(int id)
        {
            var existing = GetById(id);
            if (existing == null) return;
            _events.Remove(existing);
            SaveChanges();
        }
    }
}
