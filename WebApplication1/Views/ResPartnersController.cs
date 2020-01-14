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
    public class ResPartnersController : Controller
    {
        private readonly netCoreApp1Context _context;

        public ResPartnersController(netCoreApp1Context context)
        {
            _context = context;
        }

        // GET: ResPartners
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResPartner.ToListAsync());
        }

        // GET: ResPartners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resPartner = await _context.ResPartner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resPartner == null)
            {
                return NotFound();
            }

            return View(resPartner);
        }

        // GET: ResPartners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResPartners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Vat,Street,IsCustomer,IsProvider,Active,DateCreated")] ResPartner resPartner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resPartner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resPartner);
        }

        // GET: ResPartners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resPartner = await _context.ResPartner.FindAsync(id);
            if (resPartner == null)
            {
                return NotFound();
            }
            return View(resPartner);
        }

        // POST: ResPartners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Vat,Street,IsCustomer,IsProvider,Active,DateCreated")] ResPartner resPartner)
        {
            if (id != resPartner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resPartner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResPartnerExists(resPartner.Id))
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
            return View(resPartner);
        }

        // GET: ResPartners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resPartner = await _context.ResPartner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resPartner == null)
            {
                return NotFound();
            }

            return View(resPartner);
        }

        // POST: ResPartners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resPartner = await _context.ResPartner.FindAsync(id);
            _context.ResPartner.Remove(resPartner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResPartnerExists(int id)
        {
            return _context.ResPartner.Any(e => e.Id == id);
        }
    }
}
