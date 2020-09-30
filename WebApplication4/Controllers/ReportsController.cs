using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AllContext _context;

        public ReportsController(AllContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reports.ToListAsync());
        }


        public async Task<byte[]> GetReportAsync(int? reportId)
        {
            var userId = HttpContext.Session.GetInt32("userId");

            var readership = from r in _context.Readerships where (r.reportId == reportId && r.userId == userId) select r;

            //no existing readership
            if (readership.SingleOrDefault() == null)
            {

                var obj = new Readership()
                {
                    reportId = (int)reportId,
                    userId = (int)userId,
                    lastAccessTime = DateTime.Now,
                    view = 1
                };

                _context.Add(obj);
                await _context.SaveChangesAsync();

            }
            else
            {

                var rdObj = readership.SingleOrDefault();
                rdObj.lastAccessTime = DateTime.Now;
                rdObj.view = rdObj.view + 1;
                _context.Update(rdObj);
                await _context.SaveChangesAsync();

            }


            return await _context.Reports
                    .Where(ai => ai.id == reportId)
                    .Select(ai => ai.DataFiles)
                    .SingleOrDefaultAsync();
        }
        // GET: Reports/GetReportFile/5
        public async Task<IActionResult> GetReportFile(int? id)
        {
            var bytes = await GetReportAsync(id);
            return File(bytes, "application/pdf");
        }


        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .FirstOrDefaultAsync(m => m.id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,uploaderId")] Report report, IFormFile file)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(report);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //var userId = HttpContext.Session.GetInt32("userId");
            if (file != null)
            {
                if (file.Length > 0 && file.ContentType.Equals("application/pdf"))
                {


                    var objReport = new Report()
                    {
                        title = report.title,
                        uploaderId = report.uploaderId,
                        uploadedTime = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        objReport.DataFiles = target.ToArray();
                    }

                    _context.Add(objReport);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            ViewBag.Error = true;
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,uploaderId,Datafile,uploadedTime")] Report report)
        {
            if (id != report.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.id))
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
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .FirstOrDefaultAsync(m => m.id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.id == id);
        }
    }
}
