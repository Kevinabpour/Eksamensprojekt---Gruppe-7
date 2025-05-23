using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using System;
using System.IO;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class EditAnimalModel : PageModel
    {
        private readonly AnimalService _service;
        public EditAnimalModel(AnimalService service) => _service = service;

        [BindProperty]
        public Animal Animal { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }
        [BindProperty]
        public string ExistingPicture { get; set; }

        public IActionResult OnGet(int id)
        {
            Animal = _service.GetAnimalById(id);
            if (Animal == null) return NotFound();

            ExistingPicture = Animal.Picture;
            return Page();
        }

        public IActionResult OnPost()
        {
            // Debug: confirm handler runs and model is bound
            Console.WriteLine($"[EditAnimal] OnPost: Id={Animal.Id}, Name={Animal.Name}, Avaliability={Animal.Avaliability}");

            if (!ModelState.IsValid)
                return Page();

            if (ImageFile != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
                var mediaPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(mediaPath));
                using var fs = new FileStream(mediaPath, FileMode.Create);
                ImageFile.CopyTo(fs);
                Animal.Picture = fileName;
            }
            else
            {
                Animal.Picture = ExistingPicture;
            }

            _service.UpdateAnimal(Animal);
            return RedirectToPage("Animal");
        }
    }
}
