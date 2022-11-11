#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel.Models;

namespace hotel.Controllers
{
    public class FisicaController : Controller
    {
        private readonly MyDbContext _context;

        public FisicaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Fisica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fisica.ToListAsync());
        }

        // GET: Fisica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // GET: Fisica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fisica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cpf,rg,genero,nascimento,Id,Nome,Fone,Endereco")] Fisica fisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fisica);
        }

        // GET: Fisica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica.FindAsync(id);
            if (fisica == null)
            {
                return NotFound();
            }
            return View(fisica);
        }

        // POST: Fisica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cpf,rg,genero,nascimento,Id,Nome,Fone,Endereco")] Fisica fisica)
        {
            if (id != fisica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FisicaExists(fisica.Id))
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
            return View(fisica);
        }

        // GET: Fisica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // POST: Fisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisica = await _context.Fisica.FindAsync(id);
            _context.Fisica.Remove(fisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FisicaExists(int id)
        {
            return _context.Fisica.Any(e => e.Id == id);
        }
    }
}
