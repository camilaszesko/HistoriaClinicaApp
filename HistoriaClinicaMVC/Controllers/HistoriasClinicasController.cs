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
    public class HistoriasClinicasController : Controller
    {
        private readonly HistoriaClinicaContext _context;

        public HistoriasClinicasController(HistoriaClinicaContext context)
        {
            _context = context;
        }

        // GET: HistoriasClinicas
        public async Task<IActionResult> Index()
        {
              return View(await _context.HistoriasClinicas.ToListAsync());
        }

        // GET: HistoriasClinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoriasClinicas == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoriasClinicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaClinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoriasClinicas == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas.FindAsync(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }
            return View(historiaClinica);
        }

        // POST: HistoriasClinicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (id != historiaClinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaClinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaClinicaExists(historiaClinica.Id))
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
            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoriasClinicas == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // POST: HistoriasClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoriasClinicas == null)
            {
                return Problem("Entity set 'HistoriaClinicaContext.HistoriasClinicas'  is null.");
            }
            var historiaClinica = await _context.HistoriasClinicas.FindAsync(id);
            if (historiaClinica != null)
            {
                _context.HistoriasClinicas.Remove(historiaClinica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaClinicaExists(int id)
        {
          return _context.HistoriasClinicas.Any(e => e.Id == id);
        }
    }
}
