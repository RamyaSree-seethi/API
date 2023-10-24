using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayHappy.Models;

namespace StayHappy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly StayHappyDbContext _context;

        public RoomDetailsController(StayHappyDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDetails>>> GetRoomDetails()
        {
            return await _context.RoomDetails.ToListAsync();
        }

        // GET: api/RoomDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetails>> GetRoomDetails(int id)
        {
            var roomDetails = await _context.RoomDetails.FindAsync(id);

            if (roomDetails == null)
            {
                return NotFound();
            }

            return roomDetails;
        }

        // PUT: api/RoomDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDetails(int id, RoomDetails roomDetails)
        {
            if (id != roomDetails.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(roomDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomDetailsExists(id))
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

        // POST: api/RoomDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomDetails>> PostRoomDetails(RoomDetails roomDetails)
        {
            _context.RoomDetails.Add(roomDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomDetails", new { id = roomDetails.RoomId }, roomDetails);
        }

        // DELETE: api/RoomDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDetails>> DeleteRoomDetails(int id)
        {
            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            _context.RoomDetails.Remove(roomDetails);
            await _context.SaveChangesAsync();

            return roomDetails;
        }
        // GET: api/RoomDetails/{id}/price
        [HttpGet("{id}/price")]
        public async Task<ActionResult<decimal>> GetRoomPrice(int id)
        {
            var roomDetails = await _context.RoomDetails.FindAsync(id);

            if (roomDetails == null)
            {
                return NotFound();
            }

            return roomDetails.Price; // Assuming 'Price' is the property in your RoomDetails model that represents the room's price
        }


        private bool RoomDetailsExists(int id)
        {
            return _context.RoomDetails.Any(e => e.RoomId == id);
        }
    }
}
