using ASP_MVC_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private FlightsDbContext db;
        public AccountController(FlightsDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(
                    user => user.Login == model.Login && 
                    user.Password == model.Password); 
                if (user != null)
                {
                    await Authentification(model.Login);
                    return RedirectToAction("Index", "Home", user);
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль от аккаунта");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync
                    (user => user.Login == model.Login);
                if (user == null)
                {
                    User newUser = new User
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        DocumentNumber = model.DocumentNumber,
                        Login = model.Login,
                        Password = model.Password,
                        RoleId = 1,
                        Airtickets = new List<Airticket> { }
                    };
                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();
                    await Authentification(model.Login);
                    return RedirectToAction("Index", "Home", newUser);
                }
                else
                {
                    ModelState.AddModelError("", "Такой пользователь уже существует");
                }
            }
            return View(model);
        }

        private async Task Authentification(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookies",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login", "Account");
        }
    }
}
