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
    public class ProductosFacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosFacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductosFacturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductosFactura.Include(p => p.Factura).Include(p => p.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductosFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFactura
                .Include(p => p.Factura)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductosFacturaID == id);
            if (productosFactura == null)
            {
                return NotFound();
            }

            return View(productosFactura);
        }

        // GET: ProductosFacturas/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre");
            return View();
        }

        // POST: ProductosFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductosFacturaID,FacturaId,ProductoId")] ProductosFactura productosFactura)
        {
            try
            {
                _context.Add(productosFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", productosFactura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre", productosFactura.ProductoId);
            return View(productosFactura);
        }

        // GET: ProductosFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFactura.FindAsync(id);
            if (productosFactura == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", productosFactura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre", productosFactura.ProductoId);
            return View(productosFactura);
        }

        // POST: ProductosFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductosFacturaID,FacturaId,ProductoId")] ProductosFactura productosFactura)
        {
            if (id != productosFactura.ProductosFacturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosFacturaExists(productosFactura.ProductosFacturaID))
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
            ViewData["FacturaId"] = new SelectList(_context.Factura, "FacturaId", "FacturaId", productosFactura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "Nombre", productosFactura.ProductoId);
            return View(productosFactura);
        }

        // GET: ProductosFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosFactura = await _context.ProductosFactura
                .Include(p => p.Factura)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductosFacturaID == id);
            if (productosFactura == null)
            {
                return NotFound();
            }

            return View(productosFactura);
        }

        // POST: ProductosFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productosFactura = await _context.ProductosFactura.FindAsync(id);
            if (productosFactura != null)
            {
                _context.ProductosFactura.Remove(productosFactura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosFacturaExists(int id)
        {
            return _context.ProductosFactura.Any(e => e.ProductosFacturaID == id);
        }
    }
}
