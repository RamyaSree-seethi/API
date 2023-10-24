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
    public class feedbacksController : ControllerBase
    {
        private readonly StayHappyDbContext _context;

        public feedbacksController(StayHappyDbContext context)
        {
            _context = context;
        }

        // GET: api/feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<feedback>>> GetFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        // GET: api/feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<feedback>> Getfeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfeedback(int id, feedback feedback)
        {
            if (id != feedback.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                // After updating the feedback, recalculate the average rating for the associated RoomDetails
                await UpdateAverageRatingForRoom(feedback.RoomId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
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

        // POST: api/feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<feedback>> Postfeedback(feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            // After adding a new feedback, recalculate the average rating for the associated RoomDetails
            await UpdateAverageRatingForRoom(feedback.RoomId);

            return CreatedAtAction("Getfeedback", new { id = feedback.Id }, feedback);
        }

        // DELETE: api/feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            // After deleting a feedback, recalculate the average rating for the associated RoomDetails
            await UpdateAverageRatingForRoom(feedback.RoomId);

            return NoContent();
        }

        // GET: api/feedbacks/room/{roomId}
        [HttpGet("room/{roomId}")]
        public async Task<ActionResult<double>> GetAverageRatingByRoomId(int roomId)
        {
            var feedbacksForRoom = await _context.Feedbacks
                .Where(f => f.RoomId == roomId)
                .ToListAsync();

            if (feedbacksForRoom == null || feedbacksForRoom.Count == 0)
            {
                // No feedbacks found for the specified room, you can return a default value or handle it as needed.
                return NotFound("No feedbacks found for this room.");
            }

            // Calculate the average rating for the room based on feedback
            decimal averageRatingDecimal = feedbacksForRoom.Average(f => f.Rating);
            double averageRating = (double)averageRatingDecimal;

            return Ok(averageRating);
        }

        // Helper method to update the average rating for RoomDetails
        private async Task UpdateAverageRatingForRoom(int roomId)
        {
            var roomDetails = await _context.RoomDetails.FindAsync(roomId);

            if (roomDetails != null)
            {
                var feedbacksForRoom = await _context.Feedbacks
                    .Where(f => f.RoomId == roomId)
                    .ToListAsync();

                if (feedbacksForRoom != null && feedbacksForRoom.Count > 0)
                {
                    // Calculate the average rating for the room based on feedback
                    decimal averageRatingDecimal = feedbacksForRoom.Average(f => f.Rating);
                    roomDetails.Rating = (int)averageRatingDecimal;
                }
                else
                {
                    // If there are no feedbacks, set the rating to a default value or handle it as needed
                    roomDetails.Rating = 0;
                }

                await _context.SaveChangesAsync();
            }
        }

        private bool feedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
