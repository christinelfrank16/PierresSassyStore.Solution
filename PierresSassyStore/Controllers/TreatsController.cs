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
        public ActionResult Create(Treat treat, int FlavorId)
        {
            _db.Treats.Add(treat);
            if(FlavorId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat(){TreatId = treat.TreatId, FlavorId = FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Treat model = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            ViewBag.Flavors = new SelectList(_db.Flavors.ToList(), "FlavorId", "Name");
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Treat treat, int FlavorId)
        {
            if (FlavorId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treat.TreatId, FlavorId = FlavorId });
            }
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Treat model = _db.Treats.Include(t => t.Flavors).ThenInclude(ft => ft.Flavor).FirstOrDefault(t => t.TreatId == id);
            return View(model);
        }
    }
}
