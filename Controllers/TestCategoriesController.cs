using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pathology.Models;

namespace Pathology.Controllers
{
    public class TestCategoriesController : Controller
    {
        private readonly AppDBcontext _context;

        public TestCategoriesController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: TestCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestCategory.ToListAsync());
        }

        // GET: TestCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testCategory = await _context.TestCategory
                .FirstOrDefaultAsync(m => m.TestCategoryID == id);
            if (testCategory == null)
            {
                return NotFound();
            }

            return View(testCategory);
        }

        // GET: TestCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestCategoryID,TestCategoryName,TestCategoryDescription")] TestCategory testCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testCategory);
        }

        // GET: TestCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testCategory = await _context.TestCategory.FindAsync(id);
            if (testCategory == null)
            {
                return NotFound();
            }
            return View(testCategory);
        }

        // POST: TestCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestCategoryID,TestCategoryName,TestCategoryDescription")] TestCategory testCategory)
        {
            if (id != testCategory.TestCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCategoryExists(testCategory.TestCategoryID))
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
            return View(testCategory);
        }

        // GET: TestCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testCategory = await _context.TestCategory
                .FirstOrDefaultAsync(m => m.TestCategoryID == id);
            if (testCategory == null)
            {
                return NotFound();
            }

            return View(testCategory);
        }

        // POST: TestCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testCategory = await _context.TestCategory.FindAsync(id);
            _context.TestCategory.Remove(testCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestCategoryExists(int id)
        {
            return _context.TestCategory.Any(e => e.TestCategoryID == id);
        }
    }
}
