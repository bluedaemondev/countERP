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
    public class ProductTemplatesController : Controller
    {
        private readonly netCoreApp1Context _context;

        public ProductTemplatesController(netCoreApp1Context context)
        {
            _context = context;
        }

        // GET: ProductTemplates
        public async Task<IActionResult> Index()
        {
            var netCoreApp1Context = _context.ProductTemplate.Include(p => p.ProductCategory).Include(p => p.Uom);
            return View(await netCoreApp1Context.ToListAsync());
        }

        // GET: ProductTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTemplate = await _context.ProductTemplate
                .Include(p => p.ProductCategory)
                .Include(p => p.Uom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTemplate == null)
            {
                return NotFound();
            }

            return View(productTemplate);
        }

        // GET: ProductTemplates/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descr");
            ViewData["UomId"] = new SelectList(_context.Uom, "Id", "Descr");
            return View();
        }

        // POST: ProductTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductCategoryId,UomId,DateCreated,Active")] ProductTemplate productTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descr", productTemplate.ProductCategoryId);
            ViewData["UomId"] = new SelectList(_context.Uom, "Id", "Descr", productTemplate.UomId);
            return View(productTemplate);
        }

        // GET: ProductTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTemplate = await _context.ProductTemplate.FindAsync(id);
            if (productTemplate == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descr", productTemplate.ProductCategoryId);
            ViewData["UomId"] = new SelectList(_context.Uom, "Id", "Descr", productTemplate.UomId);
            return View(productTemplate);
        }

        // POST: ProductTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductCategoryId,UomId,DateCreated,Active")] ProductTemplate productTemplate)
        {
            if (id != productTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTemplateExists(productTemplate.Id))
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
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descr", productTemplate.ProductCategoryId);
            ViewData["UomId"] = new SelectList(_context.Uom, "Id", "Descr", productTemplate.UomId);
            return View(productTemplate);
        }

        // GET: ProductTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTemplate = await _context.ProductTemplate
                .Include(p => p.ProductCategory)
                .Include(p => p.Uom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTemplate == null)
            {
                return NotFound();
            }

            return View(productTemplate);
        }

        // POST: ProductTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTemplate = await _context.ProductTemplate.FindAsync(id);
            _context.ProductTemplate.Remove(productTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTemplateExists(int id)
        {
            return _context.ProductTemplate.Any(e => e.Id == id);
        }
    }
}
