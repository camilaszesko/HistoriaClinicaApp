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
    public class MedicoPacientesController : Controller
    {
        private readonly HistoriaClinicaContext _context;

        public MedicoPacientesController(HistoriaClinicaContext context)
        {
            _context = context;
        }

        // GET: MedicoPacientes
        public async Task<IActionResult> Index()
        {
            var historiaClinicaContext = _context.MedicoPaciente.Include(m => m.Medico).Include(m => m.Paciente);
            return View(await historiaClinicaContext.ToListAsync());
        }

        // GET: MedicoPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicoPaciente == null)
            {
                return NotFound();
            }

            var medicoPaciente = await _context.MedicoPaciente
                .Include(m => m.Medico)
                .Include(m => m.Paciente)
                .FirstOrDefaultAsync(m => m.MedicoId == id);
            if (medicoPaciente == null)
            {
                return NotFound();
            }

            return View(medicoPaciente);
        }

        // GET: MedicoPacientes/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Discriminator");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Discriminator");
            return View();
        }

        // POST: MedicoPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicoId,PacienteId")] MedicoPaciente medicoPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Discriminator", medicoPaciente.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Discriminator", medicoPaciente.PacienteId);
            return View(medicoPaciente);
        }

        // GET: MedicoPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicoPaciente == null)
            {
                return NotFound();
            }

            var medicoPaciente = await _context.MedicoPaciente.FindAsync(id);
            if (medicoPaciente == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Discriminator", medicoPaciente.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Discriminator", medicoPaciente.PacienteId);
            return View(medicoPaciente);
        }

        // POST: MedicoPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicoId,PacienteId")] MedicoPaciente medicoPaciente)
        {
            if (id != medicoPaciente.MedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoPacienteExists(medicoPaciente.MedicoId))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Discriminator", medicoPaciente.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Discriminator", medicoPaciente.PacienteId);
            return View(medicoPaciente);
        }

        // GET: MedicoPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicoPaciente == null)
            {
                return NotFound();
            }

            var medicoPaciente = await _context.MedicoPaciente
                .Include(m => m.Medico)
                .Include(m => m.Paciente)
                .FirstOrDefaultAsync(m => m.MedicoId == id);
            if (medicoPaciente == null)
            {
                return NotFound();
            }

            return View(medicoPaciente);
        }

        // POST: MedicoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicoPaciente == null)
            {
                return Problem("Entity set 'HistoriaClinicaContext.MedicoPaciente'  is null.");
            }
            var medicoPaciente = await _context.MedicoPaciente.FindAsync(id);
            if (medicoPaciente != null)
            {
                _context.MedicoPaciente.Remove(medicoPaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoPacienteExists(int id)
        {
          return _context.MedicoPaciente.Any(e => e.MedicoId == id);
        }
    }
}
