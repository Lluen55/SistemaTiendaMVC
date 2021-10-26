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
    public class CompraProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompraProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompraProducto.Include(c => c.Proveedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompraProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.CompraProducto
                .Include(c => c.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraProducto == null)
            {
                return NotFound();
            }

            return View(compraProducto);
        }

        // GET: CompraProductos/Create
        public IActionResult Create()
        {
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial");
            return View();
        }

        // POST: CompraProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProveedorId,CantidadPorProducto,FechaCompra")] CompraProducto compraProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", compraProducto.ProveedorId);
            return View(compraProducto);
        }

        // GET: CompraProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.CompraProducto.FindAsync(id);
            if (compraProducto == null)
            {
                return NotFound();
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", compraProducto.ProveedorId);
            return View(compraProducto);
        }

        // POST: CompraProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProveedorId,CantidadPorProducto,FechaCompra")] CompraProducto compraProducto)
        {
            if (id != compraProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraProductoExists(compraProducto.Id))
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
            ViewData["ProveedorId"] = new SelectList(_context.Proveedor, "Id", "RazonSocial", compraProducto.ProveedorId);
            return View(compraProducto);
        }

        // GET: CompraProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.CompraProducto
                .Include(c => c.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraProducto == null)
            {
                return NotFound();
            }

            return View(compraProducto);
        }

        // POST: CompraProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraProducto = await _context.CompraProducto.FindAsync(id);
            _context.CompraProducto.Remove(compraProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraProductoExists(int id)
        {
            return _context.CompraProducto.Any(e => e.Id == id);
        }
    }
}
