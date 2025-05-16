using Eksamensprojekt___Gruppe_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// by Ahmed

namespace Eksamensprojekt___Gruppe_7.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public static List<Employee> TempEmployees { get; set; } = new List<Employee>();
        public List <Employee> Employees { get; set; }
        public void OnGet()
        {
            if (TempEmployees.Count == 0)
            {
                TempEmployees.AddRange(new List<Employee>
                {

                 new Employee("Mads","Mads.png", "12344321", "Mads@ri.dk", "Ansvarlig" ),
                 new Employee("Maja","Maja.png", "12344330", "Maja@ri.dk", "Dyrepasser" ),
                 new Employee("Claus","Claus.png", "45875496", "--------", "Frivillig" )
                });
            }
            Employees = TempEmployees;
        }
    }
}
