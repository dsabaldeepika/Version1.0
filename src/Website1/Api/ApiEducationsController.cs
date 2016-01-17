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
    [Route("api/ApiEducations")]
    public class ApiEducationsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiEducations
        [HttpGet]
        public IEnumerable<Education> GetEducation()
        {
            return _context.Education;
        }

        // GET: api/ApiEducations/5
        [HttpGet("{id}", Name = "GetEducation")]
        public async Task<IActionResult> GetEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Education education = await _context.Education.SingleAsync(m => m.Id == id);

            if (education == null)
            {
                return HttpNotFound();
            }

            return Ok(education);
        }

        // PUT: api/ApiEducations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation([FromRoute] int id, [FromBody] Education education)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != education.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/ApiEducations
        [HttpPost]
        public async Task<IActionResult> PostEducation([FromBody] Education education)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Education.Add(education);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EducationExists(education.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEducation", new { id = education.Id }, education);
        }

        // DELETE: api/ApiEducations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Education education = await _context.Education.SingleAsync(m => m.Id == id);
            if (education == null)
            {
                return HttpNotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return Ok(education);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationExists(int id)
        {
            return _context.Education.Count(e => e.Id == id) > 0;
        }
    }
}