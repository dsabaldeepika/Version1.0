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
    [Route("api/ApiContactInfoes")]
    public class ApiContactInfoesController : Controller
    {
        private ApplicationDbContext _context;

        public ApiContactInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiContactInfoes
        [HttpGet]
        public IEnumerable<ContactInfo> GetContactInfo()
        {
            return _context.ContactInfo;
        }

        // GET: api/ApiContactInfoes/5
        [HttpGet("{id}", Name = "GetContactInfo")]
        public async Task<IActionResult> GetContactInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            ContactInfo contactInfo = await _context.ContactInfo.SingleAsync(m => m.id == id);

            if (contactInfo == null)
            {
                return HttpNotFound();
            }

            return Ok(contactInfo);
        }

        // PUT: api/ApiContactInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInfo([FromRoute] int id, [FromBody] ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != contactInfo.id)
            {
                return HttpBadRequest();
            }

            _context.Entry(contactInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
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

        // POST: api/ApiContactInfoes
        [HttpPost]
        public async Task<IActionResult> PostContactInfo([FromBody] ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.ContactInfo.Add(contactInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactInfoExists(contactInfo.id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetContactInfo", new { id = contactInfo.id }, contactInfo);
        }

        // DELETE: api/ApiContactInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            ContactInfo contactInfo = await _context.ContactInfo.SingleAsync(m => m.id == id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }

            _context.ContactInfo.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return Ok(contactInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfo.Count(e => e.id == id) > 0;
        }
    }
}