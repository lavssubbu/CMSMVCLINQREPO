using CMSRepoPatternMVCDemo.Models;
using CMSRepoPatternMVCDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace CMSRepoPatternMVCDemo.Service
{
    public class EmployeeService : IEmployee,IDepartment
    {
        private readonly EmpContext _context;

        public EmployeeService(EmpContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmp()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
           Employee empl= _context.Employees.FirstOrDefault(e =>e.EmpId== id) ?? new Employee();
           return empl;
        }
        public void AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                
                if (emp.DepId.HasValue)
                {
                   
                    var department = _context.Departments.FirstOrDefault(d => d.DepId == emp.DepId);
                    if (department != null)
                    {
                        _context.Employees.Add(emp);
                        _context.SaveChanges();
                    }
                    else
                    {
                       throw new InvalidOperationException("Invalid Department ID");
                    }
                }
                else
                {
                   throw new InvalidOperationException("Department ID cannot be null");
                }
            }
        }

        public IEnumerable<Department> GetAllDepts()
        {
           return _context.Departments.ToList();
        }

        public Employee UpdateEmployee(int id, Employee newemp)
        {
            Employee exisempl = _context.Employees.FirstOrDefault(e => e.EmpId == id) ?? new Employee();
            exisempl.EmpName = newemp.EmpName;
            exisempl.Desig = newemp.Desig;
            exisempl.JoiningDate = newemp.JoiningDate;
            exisempl.Salary=newemp.Salary;
            exisempl.DepId = newemp.DepId;

            _context.SaveChanges();
                return exisempl;
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> SearchEmployees(string searchterm)
        {
            if(string.IsNullOrEmpty(searchterm))
            {
                return _context.Employees.ToList();
            }
          searchterm =  searchterm.ToLower();
            //LINQ Method Syntax
          return  _context.Employees
                 .Where(e => e.EmpName.ToLower().Contains(searchterm)
                            || e.Desig.ToLower().Contains(searchterm)
                           || e.department.DepName.ToLower().Contains(searchterm))
                 .Include(d => d.department)
                 .ToList();

        }

        public IEnumerable<Employee> FilterEmployees(decimal? minsal, decimal? maxsal)
        {
            var query = _context.Employees.AsQueryable();

            if(minsal.HasValue)
            {
                query = query.Where(p=>p.Salary >= minsal.Value);
            }
            if (maxsal.HasValue)
            {
                query = query.Where(p => p.Salary <= maxsal.Value);
            }
            return query.Include(d=>d.department).ToList();
        }
    }
}
