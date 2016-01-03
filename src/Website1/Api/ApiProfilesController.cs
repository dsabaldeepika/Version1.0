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
    [Route("api/ApiProfiles")]
    public class ApiProfilesController : Controller
    {
        private ApplicationDbContext _context;

        public ApiProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiProfiles
        [HttpGet]
        public IEnumerable<Profile> GetProfile()
        {
            return _context.Profile;
        }

        // GET: api/ApiProfiles/5
        [HttpGet("{id}", Name = "GetProfile")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Profile profile = await _context.Profile.SingleAsync(m => m.Id == id);

            if (profile == null)
            {
                return HttpNotFound();
            }

            return Ok(profile);
        }

        // PUT: api/ApiProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile([FromRoute] int id, [FromBody] Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/ApiProfiles
        [HttpPost]
        public async Task<IActionResult> PostProfile([FromBody] Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Profile.Add(profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfileExists(profile.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/ApiProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Profile profile = await _context.Profile.SingleAsync(m => m.Id == id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Count(e => e.Id == id) > 0;
        }
    }
}