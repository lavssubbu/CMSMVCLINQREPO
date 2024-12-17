using CMSRepoPatternMVCDemo.Models;
using CMSRepoPatternMVCDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMSRepoPatternMVCDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _empser;
        private readonly IDepartment _depser;

        public EmployeesController(IEmployee empser,IDepartment depser)
        {
            _empser = empser;
            _depser = depser;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            IEnumerable<Employee> lstemp = _empser.GetAllEmp();
            return View(lstemp);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var Empl = _empser.GetEmployee(id);
            return View(Empl);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            var depts = _depser.GetAllDepts();
            ViewBag.Dept = new SelectList(depts, "DepId", "DepName");
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                var depts = _depser.GetAllDepts();
              //  var depts = _empser.GetAllEmp();
                ViewBag.Dept = new SelectList(depts, "DepId", "DepName");
                _empser.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var depts = _depser.GetAllDepts();
            ViewBag.DepId = new SelectList(depts, "DepId", "DepName");
            var Empl = _empser.GetEmployee(id);
            return View(Empl);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employee emp)
        {
            try
            {
                var depts = _depser.GetAllDepts();
                ViewBag.DepId = new SelectList(depts, "DepId", "DepName");
                _empser.UpdateEmployee(id, emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Search(string searchterm)
        {
          var Employess =  _empser.SearchEmployees(searchterm);
            return View("Index",Employess);
        }
        [HttpGet]
        public IActionResult SearchSalary(decimal minsal,decimal maxsal)
        {
            var Employess = _empser.FilterEmployees(minsal, maxsal);
            return View("Index", Employess);
        }
    }
}
