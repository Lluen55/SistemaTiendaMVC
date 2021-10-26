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
    public class VentaProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VentaProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VentaProducto.Include(v => v.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VentaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // GET: VentaProductos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Direccion");
            return View();
        }

        // POST: VentaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,TotalProductos,CantidadPorProducto,ImporteTotal,ImporteRecibido,ImporteCambio,FechaRegistro")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Direccion", ventaProducto.ClienteId);
            return View(ventaProducto);
        }

        // GET: VentaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            if (ventaProducto == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Direccion", ventaProducto.ClienteId);
            return View(ventaProducto);
        }

        // POST: VentaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,TotalProductos,CantidadPorProducto,ImporteTotal,ImporteRecibido,ImporteCambio,FechaRegistro")] VentaProducto ventaProducto)
        {
            if (id != ventaProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaProductoExists(ventaProducto.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Direccion", ventaProducto.ClienteId);
            return View(ventaProducto);
        }

        // GET: VentaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // POST: VentaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            _context.VentaProducto.Remove(ventaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaProductoExists(int id)
        {
            return _context.VentaProducto.Any(e => e.Id == id);
        }
    }
}
