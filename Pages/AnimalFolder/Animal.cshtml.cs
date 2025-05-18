using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using Eksamensprojekt___Gruppe_7.Repositories;


namespace Eksamensprojekt___Gruppe_7.Pages.AnimalFolder
{
    public class AnimalModel : PageModel
    {

        private readonly AnimalService _ms;

        public AnimalModel(AnimalService ms)
        {
            _ms = ms;
        }
        public List<Animal> Animals { set; get; }


        public void OnGet()
        {
            Animals = _ms.GetAll();
        }
    }
}
