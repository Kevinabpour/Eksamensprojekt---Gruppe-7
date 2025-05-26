// Repositories/BookingRepo.cs
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Eksamensprojekt___Gruppe_7.Models;

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    // Loads and save of booking data to Data JSON file.
    public class BookingRepo
    {
        // Path to Data/bookings.json
        private readonly string _path = Path.Combine(
            Directory.GetCurrentDirectory(), "Data", "bookings.json"
        );

        // Bookings loaded from that file
        private List<Booking> _bookings;

        public BookingRepo()
        {
            // Ensure the Data folder exists
            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

            // If it doesn't exist, create a new one
            if (!File.Exists(_path))
                File.WriteAllText(_path, "[]");

            // Read the JSON text and deserialize into the list
            var json = File.ReadAllText(_path);
            _bookings = JsonSerializer.Deserialize<List<Booking>>(json)
                        ?? new List<Booking>();
        }

        private void SaveChanges()
        {
            // Serialize
            File.WriteAllText(_path, JsonSerializer.Serialize(_bookings));
        }

        // Returns all bookings in memory
        public List<Booking> GetAll() => _bookings;

        // Adds a new booking to the list and saves
        public void Add(Booking booking)
        {
            _bookings.Add(booking);
            SaveChanges();
        }
    }
}