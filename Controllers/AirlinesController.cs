using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_Project.Models;

namespace ASP_MVC_Project.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly FlightsDbContext _context;

        public AirlinesController(FlightsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Airlines != null ? 
                          View(await _context.Airlines.ToListAsync()) :
                          Problem("Entity set 'FlightsDbContext.Airlines'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Airlines == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,License")] Airline airline)
        {
            _context.Add(airline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Airlines == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,License")] Airline airline)
        {
            if (id != airline.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(airline);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(airline.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }                
            return View(airline);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Airlines == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Airlines == null)
            {
                return Problem("Entity set 'FlightsDbContext.Airlines'  is null.");
            }
            var airline = await _context.Airlines.FindAsync(id);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
            return (_context.Airlines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
