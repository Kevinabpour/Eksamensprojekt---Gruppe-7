using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
//by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class EditModel : PageModel
    {

        // Instance of the service used to perform employee operations 
        private readonly EmployeeService _service = new EmployeeService();

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        //this property is bound to the form inputs in edit.cshtml
        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public string ExistingPicture { get; set; }

        public IActionResult OnGet()
        {

            //get an employee by ID
            Employee = _service.GetById(Id);
            
                if (Employee == null)
                {
                return RedirectToPage("/Employees/Index");
                }

            //save old pic
            ExistingPicture = Employee.Picture;
            return Page();
        }
            
        //this method is called when the form is submitted
        public IActionResult OnPost()
        {

            //if no new pic was set, use the existing one
            if (string.IsNullOrEmpty(Employee.Picture))
            {
                Employee.Picture = ExistingPicture;
            }

            //update employee data
            _service.Update(Employee);

            //set a message to show after editing
            TempData["Message"] = "Medarbejderen blev opdateret!";

            //redirect to the main list after editing
            return RedirectToPage("/Employees/Index");

        }
    }
}