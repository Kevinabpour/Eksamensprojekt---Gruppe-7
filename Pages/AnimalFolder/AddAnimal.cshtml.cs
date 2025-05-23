using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using System;
using System.IO;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class AddAnimalModel : PageModel
    {
        private readonly AnimalService _service;
        public AddAnimalModel(AnimalService service) => _service = service;

        [BindProperty]
        public Animal Animal { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // Debug: ensure this handler runs
            Console.WriteLine($"[AddAnimal] OnPost: Name={Animal?.Name}, Avaliability={Animal?.Avaliability}");

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

            _service.CreateAnimal(Animal);
            return RedirectToPage("Animal");
        }
    }
}
