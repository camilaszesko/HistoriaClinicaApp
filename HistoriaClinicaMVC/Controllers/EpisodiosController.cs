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
    public class EpisodiosController : Controller
    {
        private readonly HistoriaClinicaContext _context;

        public EpisodiosController(HistoriaClinicaContext context)
        {
            _context = context;
        }

        // GET: Episodios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Episodios.ToListAsync());
        }

        // GET: Episodios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // GET: Episodios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Episodios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HistoriaClinicaId,EmpleadoId,Descripcion,Motivo,FechaYHoraInicio,FechaYHoraAlta,Especialidad")] Episodio episodio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(episodio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(episodio);
        }

        // GET: Episodios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio == null)
            {
                return NotFound();
            }
            return View(episodio);
        }

        // POST: Episodios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HistoriaClinicaId,EmpleadoId,Descripcion,Motivo,FechaYHoraInicio,FechaYHoraAlta,Especialidad")] Episodio episodio)
        {
            if (id != episodio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodioExists(episodio.Id))
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
            return View(episodio);
        }

        // GET: Episodios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Episodios == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // POST: Episodios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Episodios == null)
            {
                return Problem("Entity set 'HistoriaClinicaContext.Episodios'  is null.");
            }
            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio != null)
            {
                _context.Episodios.Remove(episodio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodioExists(int id)
        {
          return _context.Episodios.Any(e => e.Id == id);
        }
    }
}
