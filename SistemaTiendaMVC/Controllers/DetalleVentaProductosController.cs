using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTiendaMVC.Data;
using SistemaTiendaMVC.Models;

namespace SistemaTiendaMVC.Controllers
{
    public class DetalleVentaProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleVentaProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleVentaProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleVentaProducto.Include(d => d.VentasProducto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleVentaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentaProducto = await _context.DetalleVentaProducto
                .Include(d => d.VentasProducto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleVentaProducto == null)
            {
                return NotFound();
            }

            return View(detalleVentaProducto);
        }

        // GET: DetalleVentaProductos/Create
        public IActionResult Create()
        {
            ViewData["VentasProductoId"] = new SelectList(_context.VentaProducto, "Id", "Id");
            return View();
        }

        // POST: DetalleVentaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VentasProductoId,CantidadPorProducto,PrecioUnitarioVenta,ImporteTotalPorProducto,FechaRegistro")] DetalleVentaProducto detalleVentaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVentaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VentasProductoId"] = new SelectList(_context.VentaProducto, "Id", "Id", detalleVentaProducto.VentasProductoId);
            return View(detalleVentaProducto);
        }

        // GET: DetalleVentaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentaProducto = await _context.DetalleVentaProducto.FindAsync(id);
            if (detalleVentaProducto == null)
            {
                return NotFound();
            }
            ViewData["VentasProductoId"] = new SelectList(_context.VentaProducto, "Id", "Id", detalleVentaProducto.VentasProductoId);
            return View(detalleVentaProducto);
        }

        // POST: DetalleVentaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VentasProductoId,CantidadPorProducto,PrecioUnitarioVenta,ImporteTotalPorProducto,FechaRegistro")] DetalleVentaProducto detalleVentaProducto)
        {
            if (id != detalleVentaProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVentaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentaProductoExists(detalleVentaProducto.Id))
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
            ViewData["VentasProductoId"] = new SelectList(_context.VentaProducto, "Id", "Id", detalleVentaProducto.VentasProductoId);
            return View(detalleVentaProducto);
        }

        // GET: DetalleVentaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleVentaProducto = await _context.DetalleVentaProducto
                .Include(d => d.VentasProducto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleVentaProducto == null)
            {
                return NotFound();
            }

            return View(detalleVentaProducto);
        }

        // POST: DetalleVentaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleVentaProducto = await _context.DetalleVentaProducto.FindAsync(id);
            _context.DetalleVentaProducto.Remove(detalleVentaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentaProductoExists(int id)
        {
            return _context.DetalleVentaProducto.Any(e => e.Id == id);
        }
    }
}
