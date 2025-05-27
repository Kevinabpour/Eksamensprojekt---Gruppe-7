using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Service;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class AddAnimalModel : PageModel
    {
        private readonly AnimalService _service;

        public AddAnimalModel(AnimalService service)
        {
            _service = service;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public void OnGet()
        {
        
        }

        public async Task<IActionResult> OnPostAsync()
        {

            // If the user selected a picture file, save it to wwwroot/media/
            if (ImageFile != null)
            {
                string fileExtension = Path.GetExtension(ImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;

                string mediaFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");
                string fullPath = Path.Combine(mediaFolder, fileName);

                if (!Directory.Exists(mediaFolder))
                {
                    Directory.CreateDirectory(mediaFolder);
                }

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Store filename in model
                Animal.Picture = fileName;
            }

            // Save the new animal
            _service.CreateAnimal(Animal);

            // Go back to the list of animals
            return RedirectToPage("Animal");
        }
    }
}

