using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuchosAmuchos.Data;
using MuchosAmuchos.Models;

namespace MuchosAmuchos.Controllers
{
    public class CursoEstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoEstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursoEstudiantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CursoEstudiante.Include(c => c.Curso).Include(c => c.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CursoEstudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEstudiante = await _context.CursoEstudiante
                .Include(c => c.Curso)
                .Include(c => c.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }

            return View(cursoEstudiante);
        }

        // GET: CursoEstudiantes/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Set<Curso>(), "IdCurso", "Nombre");
            ViewData["IdEstudiante"] = new SelectList(_context.Set<Estudiante>(), "IdEstudiante", "Nombre");
            return View();
        }

        // POST: CursoEstudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEstudiante,IdCurso")] CursoEstudiante cursoEstudiante)
        {
            try
            {
                _context.Add(cursoEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            ViewData["IdCurso"] = new SelectList(_context.Set<Curso>(), "IdCurso", "IdCurso", cursoEstudiante.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Set<Estudiante>(), "IdEstudiante", "IdEstudiante", cursoEstudiante.IdEstudiante);
            return View(cursoEstudiante);
        }

        // GET: CursoEstudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEstudiante = await _context.CursoEstudiante.FindAsync(id);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Set<Curso>(), "IdCurso", "IdCurso", cursoEstudiante.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Set<Estudiante>(), "IdEstudiante", "IdEstudiante", cursoEstudiante.IdEstudiante);
            return View(cursoEstudiante);
        }

        // POST: CursoEstudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEstudiante,IdCurso")] CursoEstudiante cursoEstudiante)
        {
            if (id != cursoEstudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoEstudianteExists(cursoEstudiante.Id))
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
            ViewData["IdCurso"] = new SelectList(_context.Set<Curso>(), "IdCurso", "IdCurso", cursoEstudiante.IdCurso);
            ViewData["IdEstudiante"] = new SelectList(_context.Set<Estudiante>(), "IdEstudiante", "IdEstudiante", cursoEstudiante.IdEstudiante);
            return View(cursoEstudiante);
        }

        // GET: CursoEstudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoEstudiante = await _context.CursoEstudiante
                .Include(c => c.Curso)
                .Include(c => c.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }

            return View(cursoEstudiante);
        }

        // POST: CursoEstudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoEstudiante = await _context.CursoEstudiante.FindAsync(id);
            if (cursoEstudiante != null)
            {
                _context.CursoEstudiante.Remove(cursoEstudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoEstudianteExists(int id)
        {
            return _context.CursoEstudiante.Any(e => e.Id == id);
        }
    }
}
