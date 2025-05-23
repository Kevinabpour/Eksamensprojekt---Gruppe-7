using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class DeleteAnimalModel : PageModel
    {
        private readonly AnimalService _service;
        public DeleteAnimalModel(AnimalService service) => _service = service;

        [BindProperty]
        public Animal Animal { get; set; }

        public IActionResult OnGet(int id)
        {
            Animal = _service.GetAnimalById(id);
            if (Animal == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _service.DeleteAnimal(id);
            return RedirectToPage("Animal");
        }
    }
}