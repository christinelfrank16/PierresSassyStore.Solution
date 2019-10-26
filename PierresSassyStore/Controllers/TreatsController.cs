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
            ViewBag.FlavorIds = new SelectList(_db.Flavors.ToList(), "FlavorId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Treat treat, int FlavorIds)
        {
            _db.Treats.Add(treat);
            if(FlavorIds != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat(){TreatId = treat.TreatId, FlavorId = FlavorIds });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Treat model = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            ViewBag.FlavorIds = new SelectList(_db.Flavors.ToList(), "FlavorId", "Name");
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
            Treat thisTreat = _db.Treats.Include(t => t.Flavors).ThenInclude(ft => ft.Flavor).FirstOrDefault(t => t.TreatId == id);
            List<Flavor> flavors = _db.Flavors.ToList();
            return View(new TreatsDetailsViewModel(){Treat = thisTreat, AllFlavors = flavors});
        }

        [Authorize]
        [HttpPost, ActionName("Details")]
        public ActionResult UpdateFlavors(List<int> Flavors, int TreatId)
        {
            List<FlavorTreat> thisTreatFlavors = _db.FlavorTreats.Where(ft => ft.TreatId == TreatId).ToList();
            List<int> flavorIds = thisTreatFlavors.Select(ft => ft.FlavorId).ToList();
            foreach(int flavId in flavorIds)
            {
                if(!Flavors.Contains(flavId))
                {
                    var join = thisTreatFlavors.FirstOrDefault(tf => tf.FlavorId == flavId);
                    _db.FlavorTreats.Remove(join);
                }
            }
            foreach(int newFlavId in Flavors)
            {
                if (!flavorIds.Contains(newFlavId))
                {
                    var join = new FlavorTreat(){TreatId = TreatId, FlavorId = newFlavId };
                    _db.FlavorTreats.Add(join);
                }
            }
            _db.SaveChanges();

            return RedirectToAction("Details");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
