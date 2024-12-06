using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TaskManagerDbContext _context;

        public UserController(TaskManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.Username = updatedUser.Username;
            existingUser.PasswordHash = updatedUser.PasswordHash; // Assume password is already hashed
            // Update any additional fields as needed

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound("User not found during update.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/users/5/password
        [HttpPatch("{id}/password")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] PasswordChangeRequest request)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (request.OldPasswordHash != user.PasswordHash)
            {
                return BadRequest("Old password is incorrect.");
            }

            user.PasswordHash = request.NewPasswordHash; // Assume password is already hashed

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Password updated successfully.");
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User deleted successfully.");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }

    public class PasswordChangeRequest
    {
        public string OldPasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}
