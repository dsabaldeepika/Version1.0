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
    [Route("api/ApiSkills")]
    public class ApiSkillsController : Controller
    {
        private ApplicationDbContext _context;

        public ApiSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiSkills
        [HttpGet]
        public IEnumerable<Skill> GetSkill()
        {
            return _context.Skill;
        }

        // GET: api/ApiSkills/5
        [HttpGet("{id}", Name = "GetSkill")]
        public async Task<IActionResult> GetSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Skill skill = await _context.Skill.SingleAsync(m => m.Id == id);

            if (skill == null)
            {
                return HttpNotFound();
            }

            return Ok(skill);
        }

        // PUT: api/ApiSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill([FromRoute] int id, [FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != skill.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/ApiSkills
        [HttpPost]
        public async Task<IActionResult> PostSkill([FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Skill.Add(skill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillExists(skill.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/ApiSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Skill skill = await _context.Skill.SingleAsync(m => m.Id == id);
            if (skill == null)
            {
                return HttpNotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return _context.Skill.Count(e => e.Id == id) > 0;
        }
    }
}