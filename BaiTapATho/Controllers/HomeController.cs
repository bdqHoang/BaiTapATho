using BaiTapATho.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BaiTapATho.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EmplyeeManagementContext data = new EmplyeeManagementContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Login") == "null" || HttpContext.Session.GetString("Login") == null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                var dataEmployee = data.Employees.ToList();
                return View(dataEmployee);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult LoadData()
        {
            var listData = data.Employees.ToList();
            return Json(listData);
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            employee.Status = true;
            data.Employees.Add(employee);
            data.SaveChanges();
            return Json(employee);
        }

        [HttpGet]

        public ActionResult DeleteEmployee(string id)
        {
            var obj = data.Employees.FirstOrDefault(x => x.EmployeeId == id);
            data.Remove(obj);
            data.SaveChanges();
            return Json(obj);
        }

        [HttpPut]
        public ActionResult EditEmployee(string id, Employee em)
        {
            return View();
        }
    }
}