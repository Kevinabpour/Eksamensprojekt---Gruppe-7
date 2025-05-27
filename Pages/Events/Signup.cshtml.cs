using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Repositories;

namespace Eksamensprojekt___Gruppe_7.Pages.Events
{
    public class SignupModel : PageModel
    {
        private readonly IEventRepo _repo;

        public SignupModel(IEventRepo repo)
        {
            _repo = repo;
        }

        // Binds the Event
        [BindProperty]
        public Event Event { get; set; }

        // Bind a Participant
        [BindProperty]
        public Participant Participant { get; set; }

        // Loads the event details
        public IActionResult OnGet(int id)
        {
            Event = _repo.GetById(id);
            if (Event == null) return NotFound();
            return Page();
        }

        // Adds the participant and saves
        public IActionResult OnPost()
        {

            // Retrieves the event, adds new participant, and save
            var ev = _repo.GetById(Event.Id);
            ev.Participants.Add(Participant);
            _repo.Update(ev);

            // After sign-up this redirects back to the list of events
            return RedirectToPage("Index");
        }
    }
}
