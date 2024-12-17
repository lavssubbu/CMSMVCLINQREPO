using CMSRepoPatternMVCDemo.Models;

namespace CMSRepoPatternMVCDemo.Repository
{
    public interface IEmployee
    {
       IEnumerable<Employee> GetAllEmp();
       Employee  GetEmployee(int id);
        void AddEmployee(Employee emp);
        Employee UpdateEmployee(int id, Employee emp);
        void DeleteEmployee(int id);
        IEnumerable<Employee> SearchEmployees(string searchterm);
        IEnumerable<Employee> FilterEmployees(decimal? minsal, decimal? maxsal);
    }
}
