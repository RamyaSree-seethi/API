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
    public class HotelBookingsController : ControllerBase
    {
        private readonly EmailRequest emailService;
        private readonly StayHappyDbContext _context;

        public HotelBookingsController(EmailRequest emailService, StayHappyDbContext context)
        {
            this.emailService = emailService;
            _context = context;
        }


        // GET: api/HotelBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBookings>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/HotelBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBookings>> GetHotelBookings(int id)
        {
            var hotelBookings = await _context.Bookings.FindAsync(id);

            if (hotelBookings == null)
            {
                return NotFound();
            }

            return hotelBookings;
        }

        // PUT: api/HotelBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelBookings(int id, HotelBookings hotelBookings)
        {
            if (id != hotelBookings.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(hotelBookings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelBookingsExists(id))
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
       


        // POST: api/HotelBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelBookings>> PostHotelBookings(HotelBookings hotelBookings)
        {
            _context.Bookings.Add(hotelBookings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelBookings", new { id = hotelBookings.BookingId }, hotelBookings);
        }

        // DELETE: api/HotelBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBookings(int id)
        {
            var hotelBookings = await _context.Bookings.FindAsync(id);
            if (hotelBookings == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(hotelBookings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/HotelBookings/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<HotelBookings>>> GetBookingsByUserId(int userId)
        {
            var bookings = await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound();
            }

            return bookings;
        }


        private bool HotelBookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
