using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensprojekt___Gruppe_7.Models;
using System.IO;
using System;
using Eksamensprojekt___Gruppe_7.Service;

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
            if (!ModelState.IsValid) return Page();

            if (ImageFile != null)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using var stream = new FileStream(path, FileMode.Create);
                ImageFile.CopyTo(stream);
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