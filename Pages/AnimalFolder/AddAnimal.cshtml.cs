using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Service;
using Eksamensprojekt___Gruppe_7.Models;


namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class AddAnimalModel : PageModel
    {
            public void OnGet()
            {
            }

            private AnimalService _ms;
            [BindProperty]
            public Animal animal { set; get; }

            public AddAnimalModel(AnimalService ms)
            {
                animal = new Animal();
                _ms = ms;
            }
            public IActionResult OnPost()
            {
                _ms.Add(animal);
                return RedirectToPage("/AnimalFolder/Animal");
            }
        }
    }
