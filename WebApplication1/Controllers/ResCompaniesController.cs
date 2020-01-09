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
    public class ResCompaniesController : Controller
    {
        private readonly netCoreApp1Context _context;

        public ResCompaniesController(netCoreApp1Context context)
        {
            _context = context;
        }

        // GET: ResCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResCompany.ToListAsync());
        }

        // GET: ResCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resCompany = await _context.ResCompany
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resCompany == null)
            {
                return NotFound();
            }

            return View(resCompany);
        }

        // GET: ResCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Vat,Street,Street2,Phone,Phone2,CState,CCountry,Active,DateCreated")] ResCompany resCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resCompany);
        }

        // GET: ResCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resCompany = await _context.ResCompany.FindAsync(id);
            if (resCompany == null)
            {
                return NotFound();
            }
            return View(resCompany);
        }

        // POST: ResCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Vat,Street,Street2,Phone,Phone2,CState,CCountry,Active,DateCreated")] ResCompany resCompany)
        {
            if (id != resCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResCompanyExists(resCompany.Id))
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
            return View(resCompany);
        }

        // GET: ResCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resCompany = await _context.ResCompany
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resCompany == null)
            {
                return NotFound();
            }

            return View(resCompany);
        }

        // POST: ResCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resCompany = await _context.ResCompany.FindAsync(id);
            _context.ResCompany.Remove(resCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResCompanyExists(int id)
        {
            return _context.ResCompany.Any(e => e.Id == id);
        }
    }
}
