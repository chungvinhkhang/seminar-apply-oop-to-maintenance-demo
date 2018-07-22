using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lyd.MoopDemo.PmsWeb.Models;
using Lyd.MoopDemo.PmsCore;

namespace Lyd.MoopDemo.PmsWeb.Controllers
{
    public class HomeController : Controller
    {
        private PmsApp _app;

        public HomeController(PmsApp app)
        {
            _app = app;
        }

        public IActionResult Index()
        {
            List<Guest> guests = _app.GetGuests();
            return View(guests);
        }

        public IActionResult Search(string name)
        {
            List<Guest> guests = _app.SearchGuest(new SearchOption(name));
            ViewBag.SearchName = name;
            return View("Index", guests);
        }

        public IActionResult CreateGuest(string name, string address, string phone, Gender gender)
        {
            Guest createdGuest = _app.CreateGuest(name, address, phone, gender);
            TempData["Message"] = $"Tạo thành công khách với mã {createdGuest.GuestCode}";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
