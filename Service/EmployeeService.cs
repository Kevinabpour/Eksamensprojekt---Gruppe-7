using Eksamensprojekt___Gruppe_7.Models;
using Eksamensprojekt___Gruppe_7.Repositories;
namespace Eksamensprojekt___Gruppe_7.Service
// by Ahmed

{
    public class EmployeeService
    {

        private readonly EmployeeRepo _repo = new EmployeeRepo();
        public List<Employee> GetAll()
        {
            return _repo.GetAll();
        }
        public Employee GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Employee employee)
        {
            _repo.Add(employee);
        }
        public void Update(Employee employee)
        {
            _repo.Update(employee);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

    }
}
