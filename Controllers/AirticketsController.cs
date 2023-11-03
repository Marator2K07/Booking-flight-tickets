using ASP_MVC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_Project.Controllers
{
    public class AirticketsController : Controller
    {
        private readonly FlightsDbContext _context;

        public AirticketsController(FlightsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Booking()
        {
            var flightsDbContext = _context.Schedules.Include(s => s.Airline);
            return View(await flightsDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Airline)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            User currentUser = new User();
            Airticket ticket = new Airticket();
            if (HttpContext.Session.GetString("User") != null)
            {
                // можно было получить текущего пользователя и через контекст,
                // по айди вычислить..., но решил вот так...
                string[] currentUserStrs = HttpContext.Session.GetString("User").Split(":");
                currentUser.Id = int.Parse(currentUserStrs[0]);
                currentUser.Name = currentUserStrs[1];
                currentUser.Surname = currentUserStrs[2];
                currentUser.DocumentNumber = currentUserStrs[3];
                currentUser.Login = currentUserStrs[4];
                currentUser.Password = currentUserStrs[5];
                currentUser.RoleId = int.Parse(currentUserStrs[6]);

                ticket.Schedule = schedule;
                ticket.User = currentUser;
                ViewData["Schedule"] = schedule;
                ViewData["User"] = currentUser;
                return View(ticket);
            }
            return NotFound();            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(int userId, int scheduleId)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Airline)
                .FirstOrDefaultAsync(m => m.Id == scheduleId);
            if (schedule == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            Airticket ticket = new Airticket();
            ticket.ScheduleId = scheduleId;
            ticket.UserId = userId;
            ticket.Schedule = schedule;
            ticket.User = user;

            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Booking", "Airtickets");
        }
    }
}
