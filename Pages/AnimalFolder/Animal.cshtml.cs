using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using System.Collections.Generic;
using Eksamensprojekt___Gruppe_7.Service;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class AnimalModel : PageModel
    {
        private readonly AnimalService _service;

        public AnimalModel(AnimalService service) => _service = service;

        public List<Animal> Animals { get; set; }

        public void OnGet()
        {
            Animals = _service.GetAllAnimals();
        }
    }
}