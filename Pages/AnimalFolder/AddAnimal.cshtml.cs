using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensprojekt___Gruppe_7.Models;
using System;
using System.IO;
using Eksamensprojekt___Gruppe_7.Service;

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
            if (!ModelState.IsValid) return Page();

            if (ImageFile != null)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                Animal.Picture = fileName;
            }

            _service.CreateAnimal(Animal);
            return RedirectToPage("Animal");
        }
    }
}