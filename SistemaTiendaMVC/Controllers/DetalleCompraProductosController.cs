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
    public class DetalleCompraProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleCompraProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleCompraProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleCompraProducto.Include(d => d.CompraProducto).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleCompraProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompraProducto = await _context.DetalleCompraProducto
                .Include(d => d.CompraProducto)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCompraProducto == null)
            {
                return NotFound();
            }

            return View(detalleCompraProducto);
        }

        // GET: DetalleCompraProductos/Create
        public IActionResult Create()
        {
            ViewData["CompraProductoId"] = new SelectList(_context.CompraProducto, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Descripcion");
            return View();
        }

        // POST: DetalleCompraProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompraProductoId,ProductoId,CantidadProducto,PrecioUnitarioCompra,PrecioUnitarioVenta,CostoTotal")] DetalleCompraProducto detalleCompraProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCompraProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraProductoId"] = new SelectList(_context.CompraProducto, "Id", "Id", detalleCompraProducto.CompraProductoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Descripcion", detalleCompraProducto.ProductoId);
            return View(detalleCompraProducto);
        }

        // GET: DetalleCompraProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompraProducto = await _context.DetalleCompraProducto.FindAsync(id);
            if (detalleCompraProducto == null)
            {
                return NotFound();
            }
            ViewData["CompraProductoId"] = new SelectList(_context.CompraProducto, "Id", "Id", detalleCompraProducto.CompraProductoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Descripcion", detalleCompraProducto.ProductoId);
            return View(detalleCompraProducto);
        }

        // POST: DetalleCompraProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompraProductoId,ProductoId,CantidadProducto,PrecioUnitarioCompra,PrecioUnitarioVenta,CostoTotal")] DetalleCompraProducto detalleCompraProducto)
        {
            if (id != detalleCompraProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCompraProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCompraProductoExists(detalleCompraProducto.Id))
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
            ViewData["CompraProductoId"] = new SelectList(_context.CompraProducto, "Id", "Id", detalleCompraProducto.CompraProductoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Descripcion", detalleCompraProducto.ProductoId);
            return View(detalleCompraProducto);
        }

        // GET: DetalleCompraProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCompraProducto = await _context.DetalleCompraProducto
                .Include(d => d.CompraProducto)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCompraProducto == null)
            {
                return NotFound();
            }

            return View(detalleCompraProducto);
        }

        // POST: DetalleCompraProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCompraProducto = await _context.DetalleCompraProducto.FindAsync(id);
            _context.DetalleCompraProducto.Remove(detalleCompraProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCompraProductoExists(int id)
        {
            return _context.DetalleCompraProducto.Any(e => e.Id == id);
        }
    }
}
