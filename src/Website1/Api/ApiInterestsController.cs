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
    [Route("api/ApiInterests")]
    public class ApiInterestsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiInterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiInterests
        [HttpGet]
        public IEnumerable<Interest> GetInterest()
        {
            return _context.Interest;
        }

        // GET: api/ApiInterests/5
        [HttpGet("{id}", Name = "GetInterest")]
        public async Task<IActionResult> GetInterest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Interest interest = await _context.Interest.SingleAsync(m => m.Id == id);

            if (interest == null)
            {
                return HttpNotFound();
            }

            return Ok(interest);
        }

        // PUT: api/ApiInterests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterest([FromRoute] int id, [FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != interest.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        // POST: api/ApiInterests
        [HttpPost]
        public async Task<IActionResult> PostInterest([FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Interest.Add(interest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InterestExists(interest.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetInterest", new { id = interest.Id }, interest);
        }

        // DELETE: api/ApiInterests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Interest interest = await _context.Interest.SingleAsync(m => m.Id == id);
            if (interest == null)
            {
                return HttpNotFound();
            }

            _context.Interest.Remove(interest);
            await _context.SaveChangesAsync();

            return Ok(interest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterestExists(int id)
        {
            return _context.Interest.Count(e => e.Id == id) > 0;
        }
    }
}