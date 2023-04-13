using API.Repositories.Data;
using Client.Base;
using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(EmployeeRepository repository) : base(repository)
        {
            this.employeeRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await employeeRepository.Get();
            var employees = new List<Employee>();
            if (result.Data != null)
            {
                employees = result.Data.ToList();
            }
            return Json(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            var result = await employeeRepository.Post(employee);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await employeeRepository.Get(id);
            return View(result.Data);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await employeeRepository.Delete(id);
            if (result.StatusCode == 201)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction("Index");
            }
            else if (result.StatusCode == 400)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(string id)
        {
            var result = await employeeRepository.Get(id);
            var employee = new Employee();
            if (result.Data != null)
            {
                employee.NIK = result.Data.NIK;
                employee.FirstName = result.Data.FirstName;
                employee.LastName = result.Data.LastName;
                employee.BirthDate = result.Data.BirthDate;
                employee.Gender = result.Data.Gender;
                employee.Email = result.Data.Email;
                employee.PhoneNumber = result.Data.PhoneNumber;
                employee.HiringDate = result.Data.HiringDate;
                employee.AddressId = result.Data.AddressId;
                employee.DepartmentId = result.Data.DepartmentId;
                employee.PositionId = result.Data.PositionId;
                employee.ManagerId = result.Data.ManagerId;
            }
            return Json(employee);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var result = await employeeRepository.Get(id);
            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee, string id)
        {
            var result = await employeeRepository.Put(employee, id);
            if (result.StatusCode == 200)
            {
                TempData["Success"] = "Data berhasil diubah";
                return RedirectToAction("Index");
            }
            else if (result.StatusCode == 400)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
