using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PierresSassyStore.Models;
using PierresSassyStore.ViewModels;

namespace PierresSassyStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly PierresSassyStoreContext _db;

        public HomeController(PierresSassyStoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<string> img_src = _db.Treats.Select(t => t.Image_url).ToList();
            img_src.Concat(_db.Flavors.Select(f => f.Image_url).ToList());
            return View(img_src);
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
    }
}
