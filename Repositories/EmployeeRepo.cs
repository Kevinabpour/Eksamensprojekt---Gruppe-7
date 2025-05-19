using System.Collections.Generic;
using Eksamensprojekt___Gruppe_7.Models;
//by Ahmed

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private static List<Employee> _employees = new List<Employee>();
        private static int nextId = 1;
        private static bool initialized = false;

        public EmployeeRepo()
        {
           if (!initialized)
            {                 
                _employees.Add(new Employee { Id = nextId++, Name = "Mads", Picture = "Mads.png", PhoneNumber ="12121250", Email ="ml@ri.dk", JobTitle = "Ansvarlig"});
                _employees.Add(new Employee { Id = nextId++, Name = "Maja",  Picture = "Maja.png", PhoneNumber = "12121259", Email = "me@ri.dk", JobTitle = "Dyrepasser" });
                _employees.Add(new Employee { Id = nextId++, Name = "Claus", Picture = "Claus.png", PhoneNumber = "40608023", Email = "------", JobTitle = "Frivillig" });
                initialized = true;
            }
        }




        //returns the list of employees
        public List<Employee> GetAll()
        {
            return new List<Employee>(_employees);
        }
        //returns an employee by id
        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
        //adds an employee to the list
        public void Add(Employee employee)
        {
            employee.Id = nextId++;
            nextId++;
            _employees.Add(employee);
        }
        //updates an employee in the list
        public void Update(Employee employee)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].Id == employee.Id)
                {
                    _employees[i] = employee;
                    break;
                }
            }
        }
        //deletes an employee from the list
        public void Delete(int id)
        {
            Employee employee= GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}

