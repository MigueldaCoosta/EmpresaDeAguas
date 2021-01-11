using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpresaDeAguas.web.Data;
using EmpresaDeAguas.web.Data.Entities;

namespace EmpresaDeAguas.web.Controllers
{
    public class ContadorsController : Controller
    {
        private readonly DataContext _context;

        public ContadorsController(DataContext context)
        {
            _context = context;
        }

        // GET: Contadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contadores.ToListAsync());
        }

        // GET: Contadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await _context.Contadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // GET: Contadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Morada,Codigo_postal")] Contador contador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contador);
        }

        // GET: Contadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await _context.Contadores.FindAsync(id);
            if (contador == null)
            {
                return NotFound();
            }
            return View(contador);
        }

        // POST: Contadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Morada,Codigo_postal")] Contador contador)
        {
            if (id != contador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContadorExists(contador.Id))
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
            return View(contador);
        }

        // GET: Contadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await _context.Contadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // POST: Contadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contador = await _context.Contadores.FindAsync(id);
            _context.Contadores.Remove(contador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContadorExists(int id)
        {
            return _context.Contadores.Any(e => e.Id == id);
        }
    }
}
