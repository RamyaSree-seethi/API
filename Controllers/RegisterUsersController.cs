using System;
using System.Collections;
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
    public class RegisterUsersController : ControllerBase
    {
        private readonly StayHappyDbContext _context;

        public RegisterUsersController(StayHappyDbContext context)
        {
            _context = context;
        }

        // GET: api/RegisterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterUsers>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/RegisterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterUsers>> GetRegisterUsers(int id)
        {
            var registerUsers = await _context.Users.FindAsync(id);

            if (registerUsers == null)
            {
                return NotFound();
            }

            return registerUsers;
        }

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisterUsers(int id, RegisterUsers registerUsers)
        {
            if (id != registerUsers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(registerUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterUsersExists(id))
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

        // POST: api/RegisterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegisterUsers>> PostRegisterUsers(RegisterUsers registerUsers)
        {
            _context.Users.Add(registerUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisterUsers", new { id = registerUsers.UserId }, registerUsers);
        }

        // DELETE: api/RegisterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegisterUsers>> DeleteRegisterUsers(int id)
        {
            var registerUsers = await _context.Users.FindAsync(id);
            if (registerUsers == null)
            {
                return NotFound();
            }

            _context.Users.Remove(registerUsers);
            await _context.SaveChangesAsync();

            return registerUsers;
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<RegisterUsers>> GetRegistration(string email, string password)
        {
            Hashtable err = new Hashtable();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("checkDuplicateUser")]
        public IActionResult CheckDuplicateUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty.");
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return Ok(new { isDuplicate = true });
            }

            return Ok(new { isDuplicate = false });
        }
    


    private bool RegisterUsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
