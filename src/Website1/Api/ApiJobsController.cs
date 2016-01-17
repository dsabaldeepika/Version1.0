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
    [Route("api/ApiJobs")]
    public class ApiJobsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiJobs
        [HttpGet]
        public IEnumerable<Job> GetJob()
        {
            return _context.Job;
        }

        // GET: api/ApiJobs/5
        [HttpGet("{id}", Name = "GetJob")]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Job job = await _context.Job.SingleAsync(m => m.Id == id);

            if (job == null)
            {
                return HttpNotFound();
            }

            return Ok(job);
        }

        // PUT: api/ApiJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob([FromRoute] int id, [FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/ApiJobs
        [HttpPost]
        public async Task<IActionResult> PostJob([FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Job.Add(job);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobExists(job.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/ApiJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Job job = await _context.Job.SingleAsync(m => m.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }

            _context.Job.Remove(job);
            await _context.SaveChangesAsync();

            return Ok(job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int id)
        {
            return _context.Job.Count(e => e.Id == id) > 0;
        }
    }
}