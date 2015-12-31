using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Website1.Models;

namespace Website1.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Job.Include(j => j.Dashboard);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Job job = await _context.Job.SingleAsync(m => m.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["DashboardId"] = new SelectList(_context.Dashboard, "DashboardId5", "Dashboard");
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DashboardId"] = new SelectList(_context.Dashboard, "DashboardId5", "Dashboard", job.DashboardId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Job job = await _context.Job.SingleAsync(m => m.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewData["DashboardId"] = new SelectList(_context.Dashboard, "DashboardId5", "Dashboard", job.DashboardId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Update(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DashboardId"] = new SelectList(_context.Dashboard, "DashboardId5", "Dashboard", job.DashboardId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Job job = await _context.Job.SingleAsync(m => m.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Job job = await _context.Job.SingleAsync(m => m.Id == id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
