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
    [Route("api/ApiLayouts")]
    public class ApiLayoutsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiLayoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiLayouts
        [HttpGet]
        public IEnumerable<Layout> GetLayout()
        {
            return _context.Layout;
        }

        // GET: api/ApiLayouts/5
        [HttpGet("{id}", Name = "GetLayout")]
        public async Task<IActionResult> GetLayout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Layout layout = await _context.Layout.SingleAsync(m => m.Id == id);

            if (layout == null)
            {
                return HttpNotFound();
            }

            return Ok(layout);
        }

        // PUT: api/ApiLayouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayout([FromRoute] int id, [FromBody] Layout layout)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != layout.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(layout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayoutExists(id))
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

        // POST: api/ApiLayouts
        [HttpPost]
        public async Task<IActionResult> PostLayout([FromBody] Layout layout)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Layout.Add(layout);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LayoutExists(layout.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetLayout", new { id = layout.Id }, layout);
        }

        // DELETE: api/ApiLayouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLayout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Layout layout = await _context.Layout.SingleAsync(m => m.Id == id);
            if (layout == null)
            {
                return HttpNotFound();
            }

            _context.Layout.Remove(layout);
            await _context.SaveChangesAsync();

            return Ok(layout);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LayoutExists(int id)
        {
            return _context.Layout.Count(e => e.Id == id) > 0;
        }
    }
}