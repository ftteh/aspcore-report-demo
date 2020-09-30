using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ReadershipsController : Controller
    {
        private readonly AllContext _context;

        public ReadershipsController(AllContext context)
        {
            _context = context;
        }

        // GET: Readerships
        public IActionResult Index()
        {
            //var allContext = _context.Readerships.Include(r => r.User).Include(r => r.report);
            //return View(await allContext.ToListAsync());



            var allContext = from rs in _context.Readerships
                             join rp in _context.Reports on rs.reportId equals rp.id
                             join us in _context.Users on rs.userId equals us.id
                             group rs by rs.reportId into g
                             select new Readership
                             {
                                 report = g.FirstOrDefault().report,
                                 lastAccessTime = g.OrderByDescending(item => item.lastAccessTime).FirstOrDefault().lastAccessTime,
                                 User = g.OrderByDescending(item => item.lastAccessTime).FirstOrDefault().User,
                                 view = g.Sum(item => item.view)

                             };
            return View(allContext.ToList());
        }
        public IActionResult Detailed()
        {
            //var allContext = _context.Readerships.Include(r => r.User).Include(r => r.report);
            //return View(await allContext.ToListAsync());



            var allContext = from rs in _context.Readerships
                             join rp in _context.Reports on rs.reportId equals rp.id
                             join us in _context.Users on rs.userId equals us.id
                             //group rs by rs.reportId into g
                             select new Readership
                             {
                                 report = rp,
                                 lastAccessTime = rs.lastAccessTime,
                                 User = us,
                                 view = rs.view

                             };
            return View(allContext.ToList());
        }

        // GET: Readerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readership = await _context.Readerships
                .Include(r => r.User)
                .Include(r => r.report)
                .FirstOrDefaultAsync(m => m.id == id);
            if (readership == null)
            {
                return NotFound();
            }

            return View(readership);
        }

        // GET: Readerships/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.Users, "id", "id");
            ViewData["reportId"] = new SelectList(_context.Reports, "id", "id");
            return View();
        }

        // POST: Readerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,view,reportId,userId,lastAccessTime")] Readership readership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(readership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(_context.Users, "id", "id", readership.userId);
            ViewData["reportId"] = new SelectList(_context.Reports, "id", "id", readership.reportId);
            return View(readership);
        }

        // GET: Readerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readership = await _context.Readerships.FindAsync(id);
            if (readership == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.Users, "id", "id", readership.userId);
            ViewData["reportId"] = new SelectList(_context.Reports, "id", "id", readership.reportId);
            return View(readership);
        }

        // POST: Readerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,view,reportId,userId,lastAccessTime")] Readership readership)
        {
            if (id != readership.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(readership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReadershipExists(readership.id))
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
            ViewData["userId"] = new SelectList(_context.Users, "id", "id", readership.userId);
            ViewData["reportId"] = new SelectList(_context.Reports, "id", "id", readership.reportId);
            return View(readership);
        }

        // GET: Readerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readership = await _context.Readerships
                .Include(r => r.User)
                .Include(r => r.report)
                .FirstOrDefaultAsync(m => m.id == id);
            if (readership == null)
            {
                return NotFound();
            }

            return View(readership);
        }

        // POST: Readerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var readership = await _context.Readerships.FindAsync(id);
            _context.Readerships.Remove(readership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReadershipExists(int id)
        {
            return _context.Readerships.Any(e => e.id == id);
        }


    }
}
