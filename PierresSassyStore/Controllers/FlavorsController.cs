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
    public class FlavorsController : Controller
    {
        private readonly PierresSassyStoreContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresSassyStoreContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flavor> model = _db.Flavors.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TreatIds = new SelectList(_db.Treats.ToList(), "TreatId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Flavor flavor, int TreatIds)
        {
            _db.Flavors.Add(flavor);
            if (TreatIds != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavor.FlavorId, TreatId = TreatIds });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Flavor model = _db.Flavors.FirstOrDefault(t => t.FlavorId == id);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Flavor thisFlavor = _db.Flavors.Include(f => f.Treats).ThenInclude(ft => ft.Treat).FirstOrDefault(t => t.FlavorId == id);
            List<Treat> treats = _db.Treats.ToList();
            return View(new FlavorsDetailsViewModel() { Flavor = thisFlavor, AllTreats = treats });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(t => t.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}