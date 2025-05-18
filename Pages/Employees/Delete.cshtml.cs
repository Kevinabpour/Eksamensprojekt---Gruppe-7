using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        //binds the employee data
        [BindProperty]
        public Employee Employee { get; set; }
        //holds the index of the employee in the list
        private int employeeId = -1;

        // this method runs when the page is loaded
        public IActionResult OnGet(string id)
        {
            //loop through the list of employees(search by name)
            for (int i = 0; i < IndexModel.TempEmployees.Count; i++)
            {
                if (IndexModel.TempEmployees[i].Name == id)
                {
                    //if found, assign the employee data to the binded property
                    Employee = IndexModel.TempEmployees[i];
                    employeeId = i;
                    break;
                }
            }
            //if not found, redirect to the employee overview page
            if (employeeId == -1)
            {
                return RedirectToPage("/Employees/Index");
            }
            //show the confirmation page
            return Page(); 
        }
        // this method runs when the form is submitted
        public IActionResult OnPost()
        {
            if (Employee == null || string.IsNullOrWhiteSpace(Employee.Name) )
            {
                //if the employee is not found, redirect to the employee overview page
                return RedirectToPage("/Employees/Index");
            }
            // loop to find and remove the employee from the list
            for (int i = 0; i < IndexModel.TempEmployees.Count; i++)
            {
                if (IndexModel.TempEmployees[i].Name == Employee.Name)
                {
                    IndexModel.TempEmployees.RemoveAt(i);
                    //set a message to show after deletion
                    TempData["Message"] = "Medarbejderen blev slettet!";
                    return RedirectToPage("/Employees/Index");
                }
            }
            //redirect to the main list after deletion
            return RedirectToPage("/Employees/Index");

        }
    }
}
