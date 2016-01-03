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
    [Route("api/ApiFavorites")]
    public class ApiFavoritesController : Controller
    {
        private ApplicationDbContext _context;

        public ApiFavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiFavorites
        [HttpGet]
        public IEnumerable<Favorite> GetFavorite()
        {
            return _context.Favorite;
        }

        // GET: api/ApiFavorites/5
        [HttpGet("{id}", Name = "GetFavorite")]
        public async Task<IActionResult> GetFavorite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Favorite favorite = await _context.Favorite.SingleAsync(m => m.Id == id);

            if (favorite == null)
            {
                return HttpNotFound();
            }

            return Ok(favorite);
        }

        // PUT: api/ApiFavorites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite([FromRoute] int id, [FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != favorite.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/ApiFavorites
        [HttpPost]
        public async Task<IActionResult> PostFavorite([FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Favorite.Add(favorite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriteExists(favorite.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFavorite", new { id = favorite.Id }, favorite);
        }

        // DELETE: api/ApiFavorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Favorite favorite = await _context.Favorite.SingleAsync(m => m.Id == id);
            if (favorite == null)
            {
                return HttpNotFound();
            }

            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();

            return Ok(favorite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Count(e => e.Id == id) > 0;
        }
    }
}