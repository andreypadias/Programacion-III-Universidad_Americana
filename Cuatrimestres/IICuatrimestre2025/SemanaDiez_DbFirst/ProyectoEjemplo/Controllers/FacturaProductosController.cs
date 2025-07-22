using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoEjemplo.Data;
using ProyectoEjemplo.Models;

namespace ProyectoEjemplo.Controllers
{
    public class FacturaProductosController : Controller
    {
        private readonly AppDbContext _context;

        public FacturaProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FacturaProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacturaProducto.ToListAsync());
        }

        // GET: FacturaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaProducto = await _context.FacturaProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaProducto == null)
            {
                return NotFound();
            }

            return View(facturaProducto);
        }

        // GET: FacturaProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacturaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFactura,IdProducto")] FacturaProducto facturaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturaProducto);
        }

        // GET: FacturaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaProducto = await _context.FacturaProducto.FindAsync(id);
            if (facturaProducto == null)
            {
                return NotFound();
            }
            return View(facturaProducto);
        }

        // POST: FacturaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFactura,IdProducto")] FacturaProducto facturaProducto)
        {
            if (id != facturaProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaProductoExists(facturaProducto.Id))
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
            return View(facturaProducto);
        }

        // GET: FacturaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaProducto = await _context.FacturaProducto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaProducto == null)
            {
                return NotFound();
            }

            return View(facturaProducto);
        }

        // POST: FacturaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaProducto = await _context.FacturaProducto.FindAsync(id);
            if (facturaProducto != null)
            {
                _context.FacturaProducto.Remove(facturaProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaProductoExists(int id)
        {
            return _context.FacturaProducto.Any(e => e.Id == id);
        }
    }
}
