using BaiTapATho.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BaiTapATho.Controllers
{
    public class LoginController : Controller
    {
        EmplyeeManagementContext data  = new EmplyeeManagementContext();
        // GET: LoginController

        [HttpGet]
        public IActionResult Index()
        {
         return View();
        }

        [HttpPost]
        public JsonResult Login(string Email, string Password)
        {
            var User = data.Employees.FirstOrDefault(s => s.Email == Email && s.Password == Password);
            if (User != null)
            {
                if (User.Status != true)
                {
                    return Json(new { ok = false, message = "Tai khoan bi khoa" });
                }
                HttpContext.Session.SetString("Login", JsonConvert.SerializeObject(User));
                return Json(new { ok = true, redirectToUrl = Url.Action("Index", "Home") });
            }
            else
            {
                return Json( new { ok = false, message = "Sai thong tin tai khoan" });
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.SetString("Login","null");
            return View("Index");
        }
        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
    }
}
