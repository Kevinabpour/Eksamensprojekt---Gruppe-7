using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Service;
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

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the user uploaded a new image
            if (ImageFile != null)
            {
                // Give the image a unique name
                string fileExtension = Path.GetExtension(ImageFile.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;

                // Build path to wwwroot/media folder
                string mediaFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");
                string fullPath = Path.Combine(mediaFolder, fileName);

                // Make sure the media folder exists
                if (!Directory.Exists(mediaFolder))
                {
                    Directory.CreateDirectory(mediaFolder);
                }

                // Save the uploaded file to the media folder
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                // Set the Picture property to filename
                Animal.Picture = fileName;
            }
            else
            {
                // No new file uploaded = keep the old picture
            }

            // Save the updated animal
            _service.UpdateAnimal(Animal);

            // Go back to the animal list
            return RedirectToPage("./Animal");
        }
    }
}