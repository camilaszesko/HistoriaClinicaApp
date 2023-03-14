using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HistoriaClinicaMVC.Data;
using HistoriaClinicaMVC.Models;

namespace HistoriaClinicaMVC.Controllers
{
    public class AppsController : Controller
    {
        private readonly HistoriaClinicaContext _context;

        public AppsController(HistoriaClinicaContext context)
        {
            _context = context;
        }

        // GET: Apps
        public async Task<IActionResult> Index()
        {
              return View(await _context.App.ToListAsync());
        }

        // GET: Apps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.App == null)
            {
                return NotFound();
            }

            var app = await _context.App
                .FirstOrDefaultAsync(m => m.Id == id);
            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        // GET: Apps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono")] App app)
        {
            if (ModelState.IsValid)
            {
                _context.Add(app);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        // GET: Apps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.App == null)
            {
                return NotFound();
            }

            var app = await _context.App.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }
            return View(app);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono")] App app)
        {
            if (id != app.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(app);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppExists(app.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        // GET: Apps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.App == null)
            {
                return NotFound();
            }

            var app = await _context.App
                .FirstOrDefaultAsync(m => m.Id == id);
            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        // POST: Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.App == null)
            {
                return Problem("Entity set 'HistoriaClinicaContext.App'  is null.");
            }
            var app = await _context.App.FindAsync(id);
            if (app != null)
            {
                _context.App.Remove(app);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppExists(int id)
        {
          return _context.App.Any(e => e.Id == id);
        }
    }
}
