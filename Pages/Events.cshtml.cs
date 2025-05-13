using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Eksamensprojekt___Gruppe_7.Pages
{
    
    public class EventsModel : PageModel
    {

        private EventService _eventure;
        [BindProperty]
        public Event eventure { get; set; }
        public List<Event> events { get; set; }
        public EventsModel(EventService eventure2)
        {
            _eventure = eventure2;
            eventure = new Event();
        }



        public IActionResult OnPost()
        {
            _eventure.Add(eventure);
            return RedirectToPage("/Events");
        }

        public void OnGet()
        {
            events = _eventure.GetAll();
        }
    }
}
