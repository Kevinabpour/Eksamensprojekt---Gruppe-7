using Eksamensgruppe_7___ClassLibrary.Models;
using Eksamensgruppe_7___ClassLibrary.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class IndexModel : PageModel
    {

        // Instance of the service used to perform employee operations 
        private readonly EmployeeService _service = new EmployeeService();
      
        //brings all the employees from the repo
        public List <Employee> Employees { get; set; }

        //this method runs when the page is loaded
        public void OnGet()
        {

            //get all employees
            Employees = _service.GetAll();
        }
    }
}
