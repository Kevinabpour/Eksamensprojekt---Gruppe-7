using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeService _service = new EmployeeService();
        //brings all the employees from the repo
        public List <Employee> Employees { get; set; }
        public void OnGet()
        {
          
            Employees = _service.GetAll();
        }
    }
}
