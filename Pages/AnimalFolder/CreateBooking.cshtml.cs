using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using Eksamensprojekt___Gruppe_7.Repositories;
using System.Collections.Generic;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class CreateBookingModel : PageModel
    {
        private readonly BookingRepo _bookingRepo;
        private readonly AnimalService _animalService;

        public CreateBookingModel(BookingRepo bookingRepo, AnimalService animalService)
        {
            _bookingRepo = bookingRepo;
            _animalService = animalService;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public List<Animal> Animals { get; set; }

        public void OnGet()
        {
            Animals = _animalService.GetAllAnimals();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Animals = _animalService.GetAllAnimals();
                return Page();
            }

            _bookingRepo.Add(Booking);
            return RedirectToPage("Animal");
        }
    }
}
