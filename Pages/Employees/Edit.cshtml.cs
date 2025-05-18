using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eksamensprojekt___Gruppe_7.Models;
//by Ahmed
namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Employee Employee { get; set; }
        private int employeeId = -1 ;
        public IActionResult OnGet(string id)
        {
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
            if (employeeId == -1)
            {
                return RedirectToPage("/Employee/Index");
                // Handle the case where the employee is not found
                // For example, redirect to an error page or show a message
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            for (int i = 0; i < IndexModel.TempEmployees.Count; i++)
            {
                if (IndexModel.TempEmployees[i].Name == Employee.Name)
                {
                   IndexModel.TempEmployees[i]= Employee;
                    break;
                }
            }
            return RedirectToPage("/Employees/Index");
        }
    }
}
