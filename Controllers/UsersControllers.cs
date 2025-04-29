using CommunityAPI.Data;
using CommunityAPI.Models;
using CommunityAPI.Models.CommunityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CommunityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly CommunityDbContext _ctx;

        public UsersController(CommunityDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _ctx.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] User updatedUser)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            user.CreatedAt = updatedUser.CreatedAt;

            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
