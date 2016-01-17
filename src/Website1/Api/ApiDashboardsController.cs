using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Website1.Models;

namespace Website1.Controllers
{
    [Produces("application/json")]
    [Route("api/ApiDashboards")]
    public class ApiDashboardsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiDashboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiDashboards
        [HttpGet]
        public IEnumerable<Dashboard> GetDashboard()
        {
            return _context.Dashboard;
        }

        // GET: api/ApiDashboards/5
        [HttpGet("{id}", Name = "GetDashboard")]
        public async Task<IActionResult> GetDashboard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Dashboard dashboard = await _context.Dashboard.SingleAsync(m => m.DashboardId == id);

            if (dashboard == null)
            {
                return HttpNotFound();
            }

            return Ok(dashboard);
        }

        // PUT: api/ApiDashboards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboard([FromRoute] string id, [FromBody] Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != dashboard.DashboardId)
            {
                return HttpBadRequest();
            }

            _context.Entry(dashboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/ApiDashboards
        [HttpPost]
        public async Task<IActionResult> PostDashboard([FromBody] Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Dashboard.Add(dashboard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DashboardExists(dashboard.DashboardId))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDashboard", new { id = dashboard.DashboardId }, dashboard);
        }

        // DELETE: api/ApiDashboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashboard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Dashboard dashboard = await _context.Dashboard.SingleAsync(m => m.DashboardId == id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }

            _context.Dashboard.Remove(dashboard);
            await _context.SaveChangesAsync();

            return Ok(dashboard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DashboardExists(string id)
        {
            return _context.Dashboard.Count(e => e.DashboardId == id) > 0;
        }
    }
}