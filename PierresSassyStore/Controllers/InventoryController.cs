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
    public class InventoryController : Controller
    {
        private readonly PierresSassyStoreContext _db;

        public InventoryController(PierresSassyStoreContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flavor> flavors = _db.Flavors.OrderBy(f => f.Name).ToList();
            List<Treat> treats = _db.Treats.OrderBy(t => t.Name).ToList();
            List<FlavorTreat> combos = _db.FlavorTreats.OrderBy(ft => ft.TreatId).ToList();
            InventoryIndexViewModel model = new InventoryIndexViewModel(){ AllFlavors = flavors, AllTreats = treats, AllCombinations = combos };
            return View(model);
        }
    }
}