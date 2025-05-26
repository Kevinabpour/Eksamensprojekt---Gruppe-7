using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Service;
// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class DeleteModel : PageModel
    {

        // Instance of the service used to perform employee operations 
        private readonly EmployeeService _service = new EmployeeService();

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Employee Employee { get; set; }

        // this method runs when the page is loaded
        public IActionResult OnGet()
        {

            //get employee by ID to confirm deletion
            Employee = _service.GetById(Id);
           
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

            //delete employee by ID
            _service.Delete(Id);
            TempData["Message"] = "Medarbejderen blev slettet!";
            return RedirectToPage("/Employees/Index");

        }
    }
}
