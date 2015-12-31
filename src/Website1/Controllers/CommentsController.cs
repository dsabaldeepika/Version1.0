using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Website1.Models;

namespace Website1.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comment.Include(c => c.Dashboard);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = await _context.Comment.SingleAsync(m => m.Id == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["DashboardId"] = new SelectList(_context.Set<Dashboard>(), "DashboardId", "Dashboard");
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DashboardId"] = new SelectList(_context.Set<Dashboard>(), "DashboardId", "Dashboard", comment.DashboardId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = await _context.Comment.SingleAsync(m => m.Id == id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewData["DashboardId"] = new SelectList(_context.Set<Dashboard>(), "DashboardId", "Dashboard", comment.DashboardId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DashboardId"] = new SelectList(_context.Set<Dashboard>(), "DashboardId", "Dashboard", comment.DashboardId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Comment comment = await _context.Comment.SingleAsync(m => m.Id == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Comment comment = await _context.Comment.SingleAsync(m => m.Id == id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
