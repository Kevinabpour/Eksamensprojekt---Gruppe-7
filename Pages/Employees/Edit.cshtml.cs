using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
//by Ahmed
namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = false)]
        public string OriginalName { get; set; }
        //this property is bound to the form inputs in edit.cshtml
        [BindProperty]
        public Employee Employee { get; set; }
        //holds the index of the employee in the list
        private int employeeId = -1 ;
        //this method called when the page is loaded
        public IActionResult OnGet(string id)
        {
            //search for the employee by name in the list
            for (int i = 0; i < IndexModel.TempEmployees.Count; i++)
            {
                if (IndexModel.TempEmployees[i].Name == id)
                {
                    Employee = new Employee(
                        IndexModel.TempEmployees[i].Name,
                        IndexModel.TempEmployees[i].Picture,
                        IndexModel.TempEmployees[i].PhoneNumber,
                        IndexModel.TempEmployees[i].Email,
                        IndexModel.TempEmployees[i].JobTitle
                    );
                    employeeId = i;
                    break;
                }
            }
            //if not found, redirect to the employee overview page
            if (employeeId == -1)
            {
                return RedirectToPage("/Employees/Index");
            }
            //show the edit page with the employee data, if found
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
            //find the employee in the list by name and update their data
            for (int i = 0; i < IndexModel.TempEmployees.Count; i++)
            {
                if (IndexModel.TempEmployees[i].Name == OriginalName)
                {
                    //replace the old employee data with the updated one
                    IndexModel.TempEmployees[i]= Employee;
                    //set a message to show after editing
                    TempData["Message"] = "Medarbejderen blev opdateret!";
                    
                    return RedirectToPage("/Employees/Index");

                }
            }
            //redirect to the main list after editing
            return RedirectToPage("/Employees/Index");
        }
    }
}
