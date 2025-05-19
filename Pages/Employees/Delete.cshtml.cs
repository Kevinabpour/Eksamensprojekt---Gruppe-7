using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;
// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepo _repo = new EmployeeRepo();

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Employee Employee { get; set; }

        // this method runs when the page is loaded
        public IActionResult OnGet()
        {
            Employee = _repo.GetById(Id);
           
            //if not found, redirect to the employee overview page
            if (Employee == null)
            {
                return RedirectToPage("/Employees/Index");
            }
            //show the confirmation page
            return Page(); 
        }
        // this method runs when the form is submitted
        public IActionResult OnPost()
        {
            _repo.Delete(Id);
            TempData["Message"] = "Medarbejderen blev slettet!";
            return RedirectToPage("/Employees/Index");

        }
    }
}
