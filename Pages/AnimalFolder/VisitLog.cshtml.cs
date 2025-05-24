using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Repositories;
using Eksamensprojekt___Gruppe_7.Service;
using BookingEntry = Eksamensprojekt___Gruppe_7.Models.Booking;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class VisitLogModel : PageModel
    {
        private readonly BookingRepo _bookingRepo;
        private readonly AnimalService _animalService;

        public VisitLogModel(BookingRepo bookingRepo, AnimalService animalService)
        {
            _bookingRepo = bookingRepo;
            _animalService = animalService;
        }

        public List<BookingEntry> Bookings { get; set; }
        public List<Models.Animal> Animals { get; set; }

        public void OnGet()
        {
            Bookings = _bookingRepo.GetAll();
            Animals = _animalService.GetAllAnimals();
        }
    }
}
