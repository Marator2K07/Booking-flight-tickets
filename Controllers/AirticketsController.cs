using ASP_MVC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
