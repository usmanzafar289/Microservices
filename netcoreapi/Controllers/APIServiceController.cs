using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Mvc.Ui;
using Todo.Mvc.Ui.Models;

namespace Todo.Mvc.Ui.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIServiceController : ControllerBase
    {
        private readonly AppDBContext _context;

        public APIServiceController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/APIService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Points>>> GetPoints()
        {
            return await _context.Points.ToListAsync();
        }

        // GET: api/APIService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Points>> GetPoints(int id)
        {
            var points = await _context.Points.FindAsync(id);

            if (points == null)
            {
                return NotFound();
            }

            return points;
        }

        // PUT: api/APIService/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoints(int id, Points points)
        {
            if (id != points.id)
            {
                return BadRequest();
            }

            _context.Entry(points).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIService
        [HttpPost]
        public async Task<ActionResult<Points>> PostPoints(Points points)
        {
            _context.Points.Add(points);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoints", new { id = points.id }, points);
        }

        // DELETE: api/APIService/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Points>> DeletePoints(int id)
        {
            var points = await _context.Points.FindAsync(id);
            if (points == null)
            {
                return NotFound();
            }

            _context.Points.Remove(points);
            await _context.SaveChangesAsync();

            return points;
        }

        private bool PointsExists(int id)
        {
            return _context.Points.Any(e => e.id == id);
        }

        [Route("example1")]
        [HttpGet]
        public List<Points> GetEpoch()
        {
            var example1 = _context.Points
                                      .Where(s => s.name == "example1")
                                     .ToList();
            return example1;
        }
    }
}
