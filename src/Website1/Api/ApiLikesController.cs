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
    [Route("api/ApiLikes")]
    public class ApiLikesController : Controller
    {
        private ApplicationDbContext _context;

        public ApiLikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiLikes
        [HttpGet]
        public IEnumerable<Like> GetLike()
        {
            return _context.Like;
        }

        // GET: api/ApiLikes/5
        [HttpGet("{id}", Name = "GetLike")]
        public async Task<IActionResult> GetLike([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Like like = await _context.Like.SingleAsync(m => m.Id == id);

            if (like == null)
            {
                return HttpNotFound();
            }

            return Ok(like);
        }

        // PUT: api/ApiLikes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLike([FromRoute] int id, [FromBody] Like like)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != like.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(like).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // POST: api/ApiLikes
        [HttpPost]
        public async Task<IActionResult> PostLike([FromBody] Like like)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Like.Add(like);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeExists(like.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetLike", new { id = like.Id }, like);
        }

        // DELETE: api/ApiLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Like like = await _context.Like.SingleAsync(m => m.Id == id);
            if (like == null)
            {
                return HttpNotFound();
            }

            _context.Like.Remove(like);
            await _context.SaveChangesAsync();

            return Ok(like);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LikeExists(int id)
        {
            return _context.Like.Count(e => e.Id == id) > 0;
        }
    }
}