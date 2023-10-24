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
    public class BankCardsController : ControllerBase
    {
        private readonly StayHappyDbContext _context;

        public BankCardsController(StayHappyDbContext context)
        {
            _context = context;
        }

        // GET: api/BankCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankCard>>> GetBankCard()
        {
            return await _context.BankCard.ToListAsync();
        }

        // GET: api/BankCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankCard>> GetBankCard(int id)
        {
            var bankCard = await _context.BankCard.FindAsync(id);

            if (bankCard == null)
            {
                return NotFound();
            }

            return bankCard;
        }

        // PUT: api/BankCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankCard(int id, BankCard bankCard)
        {
            if (id != bankCard.BankCredId)
            {
                return BadRequest();
            }

            _context.Entry(bankCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCardExists(id))
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

        // POST: api/BankCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankCard>> PostBankCard(BankCard bankCard)
        {
            _context.BankCard.Add(bankCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankCard", new { id = bankCard.BankCredId }, bankCard);
        }

        // DELETE: api/BankCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankCard(int id)
        {
            var bankCard = await _context.BankCard.FindAsync(id);
            if (bankCard == null)
            {
                return NotFound();
            }

            _context.BankCard.Remove(bankCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankCardExists(int id)
        {
            return _context.BankCard.Any(e => e.BankCredId == id);
        }
    }
}
