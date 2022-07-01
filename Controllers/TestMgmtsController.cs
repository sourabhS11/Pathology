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
    public class TestMgmtsController : Controller
    {
        private readonly AppDBcontext _context;

        public TestMgmtsController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: TestMgmts
        public async Task<IActionResult> Index()
        {
            var appDBcontext = _context.TestMgmt.Include(t => t.Package).Include(t => t.TestCategory);
            return View(await appDBcontext.ToListAsync());
        }

        // GET: TestMgmts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMgmt = await _context.TestMgmt
                .Include(t => t.Package)
                .Include(t => t.TestCategory)
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (testMgmt == null)
            {
                return NotFound();
            }

            return View(testMgmt);
        }

        // GET: TestMgmts/Create
        public IActionResult Create()
        {
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName");
            ViewData["TestCategoryID"] = new SelectList(_context.TestCategory, "TestCategoryID", "TestCategoryName");
            return View();
        }

        // POST: TestMgmts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,TestName,TestPrice,TestCategoryID,PackageID")] TestMgmt testMgmt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testMgmt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName", testMgmt.PackageID);
            ViewData["TestCategoryID"] = new SelectList(_context.TestCategory, "TestCategoryID", "TestCategoryName", testMgmt.TestCategoryID);
            return View(testMgmt);
        }

        // GET: TestMgmts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMgmt = await _context.TestMgmt.FindAsync(id);
            if (testMgmt == null)
            {
                return NotFound();
            }
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName", testMgmt.PackageID);
            ViewData["TestCategoryID"] = new SelectList(_context.TestCategory, "TestCategoryID", "TestCategoryName", testMgmt.TestCategoryID);
            return View(testMgmt);
        }

        // POST: TestMgmts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestId,TestName,TestPrice,TestCategoryID,PackageID")] TestMgmt testMgmt)
        {
            if (id != testMgmt.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestMgmtExists(testMgmt.TestId))
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
            ViewData["PackageID"] = new SelectList(_context.Packages, "PackageID", "PackageName", testMgmt.PackageID);
            ViewData["TestCategoryID"] = new SelectList(_context.TestCategory, "TestCategoryID", "TestCategoryName", testMgmt.TestCategoryID);
            return View(testMgmt);
        }

        // GET: TestMgmts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMgmt = await _context.TestMgmt
                .Include(t => t.Package)
                .Include(t => t.TestCategory)
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (testMgmt == null)
            {
                return NotFound();
            }

            return View(testMgmt);
        }

        // POST: TestMgmts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testMgmt = await _context.TestMgmt.FindAsync(id);
            _context.TestMgmt.Remove(testMgmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestMgmtExists(int id)
        {
            return _context.TestMgmt.Any(e => e.TestId == id);
        }
    }
}
