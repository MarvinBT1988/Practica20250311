using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica20250311.AppWebMVC.Models;

namespace Practica20250311.AppWebMVC.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private readonly Practica20250311DbContext _context;

        public ProductosController(Practica20250311DbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(Producto producto, int topRegistro=10)
        {
            var query=_context.Productos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(producto.Nombre))            
                query = query.Where(s=> s.Nombre.Contains(producto.Nombre));            
            if (!string.IsNullOrWhiteSpace(producto.Descripcion))            
                query = query.Where(s => s.Descripcion.Contains(producto.Descripcion));            
            if (producto.MarcaId > 0)            
                query = query.Where(s=> s.MarcaId==producto.MarcaId);            
            if (producto.CategoriaId > 0)            
                query = query.Where(s => s.CategoriaId == producto.CategoriaId);            
            if(topRegistro>0)            
                query=query.Take(topRegistro);            
            query = query
                .Include(p => p.Categoria).Include(p => p.Marca);

            var marcas = _context.Marcas.ToList();
            marcas.Add(new Marca { Nombre = "SELECCIONAR", Id = 0 });           
            var categorias= _context.Categorias.ToList();
            categorias.Add(new Categoria { Nombre = "SELECCIONAR", Id = 0 });
            ViewData["CategoriaId"] = new SelectList(categorias, "Id", "Nombre",0);
            ViewData["MarcaId"] = new SelectList(marcas, "Id", "Nombre",0);

            return View(await query.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,MarcaId,CategoriaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,MarcaId,CategoriaId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
