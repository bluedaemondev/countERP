using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Views
{
    public class ProductProductsController : Controller
    {
        private readonly netCoreApp1Context _context;

        public ProductProductsController(netCoreApp1Context context)
        {
            _context = context;
        }

        // GET: ProductProducts
        public async Task<IActionResult> Index()
        {
            var netCoreApp1Context = _context.ProductProduct.Include(p => p.PrdTemplate);
            return View(await netCoreApp1Context.ToListAsync());
        }

        // GET: ProductProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProduct = await _context.ProductProduct
                .Include(p => p.PrdTemplate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productProduct == null)
            {
                return NotFound();
            }

            return View(productProduct);
        }

        // GET: ProductProducts/Create
        public IActionResult Create()
        {
            ViewData["PrdTemplateId"] = new SelectList(_context.ProductTemplate, "Id", "Name");
            return View();
        }

        // POST: ProductProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PrdTemplateId,DateCreated,Active")] ProductProduct productProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrdTemplateId"] = new SelectList(_context.ProductTemplate, "Id", "Name", productProduct.PrdTemplateId);
            return View(productProduct);
        }

        // GET: ProductProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProduct = await _context.ProductProduct.FindAsync(id);
            if (productProduct == null)
            {
                return NotFound();
            }
            ViewData["PrdTemplateId"] = new SelectList(_context.ProductTemplate, "Id", "Name", productProduct.PrdTemplateId);
            return View(productProduct);
        }

        // POST: ProductProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PrdTemplateId,DateCreated,Active")] ProductProduct productProduct)
        {
            if (id != productProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductProductExists(productProduct.Id))
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
            ViewData["PrdTemplateId"] = new SelectList(_context.ProductTemplate, "Id", "Name", productProduct.PrdTemplateId);
            return View(productProduct);
        }

        // GET: ProductProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productProduct = await _context.ProductProduct
                .Include(p => p.PrdTemplate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productProduct == null)
            {
                return NotFound();
            }

            return View(productProduct);
        }

        // POST: ProductProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productProduct = await _context.ProductProduct.FindAsync(id);
            _context.ProductProduct.Remove(productProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductProductExists(int id)
        {
            return _context.ProductProduct.Any(e => e.Id == id);
        }
    }
}
