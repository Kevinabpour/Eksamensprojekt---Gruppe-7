using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;
using System.Collections.Generic;

namespace Eksamensprojekt___Gruppe_7.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly IEventRepo _repo;
        public IndexModel(IEventRepo repo) => _repo = repo;

        public List<Event> Events { get; set; }

        public void OnGet() => Events = _repo.GetAll();
    }
}
