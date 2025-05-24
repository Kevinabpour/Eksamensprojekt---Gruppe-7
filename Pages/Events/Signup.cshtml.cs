using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;

namespace Eksamensprojekt___Gruppe_7.Pages.Events
{
    public class SignupModel : PageModel
    {
        private readonly IEventRepo _repo;
        public SignupModel(IEventRepo repo) => _repo = repo;

        [BindProperty]
        public Event Event { get; set; }

        // Now bind a Participant object
        [BindProperty]
        public Participant Participant { get; set; }

        public IActionResult OnGet(int id)
        {
            Event = _repo.GetById(id);
            if (Event == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var ev = _repo.GetById(Event.Id);
            ev.Participants.Add(Participant);
            _repo.Update(ev);  // Save the updated list
            return RedirectToPage("Index");
        }
    }
}
