using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UstaApi.Models;

namespace UstaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Masters/getall
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Master>>> GetMasters()
        {
            var masters = _context.Masters
                .ToListAsync();
            
            return await masters;
        }

        // GET: api/Masters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Master>> GetMaster(int id)
        {
            var master = await _context.Masters.FindAsync(id);

            if (master == null)
            {
                return NotFound();
            }

            return master;
        }

        // PUT: api/Masters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaster(int id, Master master)
        {
            if (id != master.MasterId)
            {
                return BadRequest();
            }

            _context.Entry(master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterExists(id))
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

        // POST: api/Masters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Master>> PostMaster(Master master)
        {
            _context.Masters.Add(master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaster", new { id = master.MasterId }, master);
        }

        // DELETE: api/Masters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Master>> DeleteMaster(int id)
        {
            var master = await _context.Masters.FindAsync(id);
            if (master == null)
            {
                return NotFound();
            }

            _context.Masters.Remove(master);
            await _context.SaveChangesAsync();

            return master;
        }

        private bool MasterExists(int id)
        {
            return _context.Masters.Any(e => e.MasterId == id);
        }
    }
}
