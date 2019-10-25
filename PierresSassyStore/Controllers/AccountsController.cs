using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PierresSassyStore.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using PierresSassyStore.ViewModels;

namespace PierresSassyStore.Controllers
{
    public class AccountsController : Controller
    {
        private readonly PierresSassyStoreContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierresSassyStoreContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                return View(currentUser);
            }
            return View("Index", "Home");
        }

        public ActionResult Register()
        {
            ViewBag.ErrorMsg = "";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
            IdentityResult result;
            try
            {
                result = await _userManager.CreateAsync(user, model.Password);
            }
            catch(ArgumentNullException)
            {
                ViewBag.ErrorMsg = "Please provide content for all values";
                return View();
            }
            if (result.Succeeded)
            {   
                return RedirectToAction("Index");
            }
            else
            {
                var errorList = result.Errors.ToList();
                string errorMsg = "The following error(s) occurred: ";
                foreach(var error in errorList)
                {
                    errorMsg += error.Code + " " + error.Description + " ";
                }
                ViewBag.ErrorMsg = errorMsg;
                return View();
            }
        }

        public ActionResult Login()
        {
            ViewBag.ErrorMsg = "";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string errorMsg ="";
                if(result.IsLockedOut)
                {
                    errorMsg = $"{model.UserName} is locked out. Please try again later.";
                }
                else if(result.IsNotAllowed)
                {
                    errorMsg = $"{model.UserName} is not allowed to sign in. Please try registering or trying again later.";
                }
                else
                {
                    errorMsg = "An unknown error occurred.";
                }
                
                ViewBag.ErrorMsg = errorMsg;
                return View();
            }
        }

        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}