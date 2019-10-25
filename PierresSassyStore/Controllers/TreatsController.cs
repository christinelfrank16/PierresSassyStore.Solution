using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PierresSassyStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PierresSassyStore.ViewModels;

namespace PierresSassyStore.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierresSassyStoreContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TreatsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresSassyStoreContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Treat> model = _db.Treats.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Flavors = new SelectList(_db.Flavors.ToList(), "FlavorId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
