using Eksamensprojekt___Gruppe_7.Models;
using System.Collections.Generic;
//by Ahmed

namespace Eksamensprojekt___Gruppe_7.Repositories
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
