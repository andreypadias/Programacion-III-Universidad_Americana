using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiposDeRelaciones.Data;
using TiposDeRelaciones.Models;

namespace TiposDeRelaciones.Controllers
{
    public class PasaportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasaportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pasaportes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pasaporte.Include(p => p.Persona);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pasaportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasaporte = await _context.Pasaporte
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.IdPasaporte == id);
            if (pasaporte == null)
            {
                return NotFound();
            }

            return View(pasaporte);
        }

        // GET: Pasaportes/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Persona, "IdPersona", "Nombre");
            return View();
        }

        // POST: Pasaportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPasaporte,Numero,Pais,FechaEmision,FechaExpiracion,IdPersona")] Pasaporte pasaporte)
        {
            try
            {
                _context.Add(pasaporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            ViewData["IdPersona"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", pasaporte.IdPersona);
            return View(pasaporte);
        }

        // GET: Pasaportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasaporte = await _context.Pasaporte.FindAsync(id);
            if (pasaporte == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", pasaporte.IdPersona);
            return View(pasaporte);
        }

        // POST: Pasaportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPasaporte,Numero,Pais,FechaEmision,FechaExpiracion,IdPersona")] Pasaporte pasaporte)
        {
            if (id != pasaporte.IdPasaporte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasaporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasaporteExists(pasaporte.IdPasaporte))
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
            ViewData["IdPersona"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", pasaporte.IdPersona);
            return View(pasaporte);
        }

        // GET: Pasaportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasaporte = await _context.Pasaporte
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.IdPasaporte == id);
            if (pasaporte == null)
            {
                return NotFound();
            }

            return View(pasaporte);
        }

        // POST: Pasaportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasaporte = await _context.Pasaporte.FindAsync(id);
            if (pasaporte != null)
            {
                _context.Pasaporte.Remove(pasaporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasaporteExists(int id)
        {
            return _context.Pasaporte.Any(e => e.IdPasaporte == id);
        }
    }
}
