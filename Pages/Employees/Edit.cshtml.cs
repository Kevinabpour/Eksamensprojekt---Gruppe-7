using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;
//by Ahmed
namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepo _repo = new EmployeeRepo();

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        //this property is bound to the form inputs in edit.cshtml
        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnGet()
        {
            Employee = _repo.GetById(Id);
            
                if (Employee == null)
                {
                return RedirectToPage("/Employees/Index");
                }
            return Page();
        }
            
        //this method is called when the form is submitted
        public IActionResult OnPost()
        {
            // Check if the form data is valid
            if (!ModelState.IsValid)
            {
                //if not, reload the page with validation messages
                return Page();
            }
           _repo.Update(Employee);
            //set a message to show after editing
            TempData["Message"] = "Medarbejderen blev opdateret!";
            //redirect to the main list after editing
            return RedirectToPage("/Employees/Index");
        }
    }
}
