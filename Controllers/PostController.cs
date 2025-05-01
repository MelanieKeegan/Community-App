using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityAPI.Data;
using CommunityAPI.Models;
using CommunityAPI.Models.CommunityAPI.Models;

namespace CommunityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly CommunityDbContext _context;

        public PostController(CommunityDbContext context)
        {
            _context = context;
        }

        // GET: api/posts
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _context.Post.ToListAsync();
            return Ok(posts);
        }

        // GET: api/posts/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetPostById(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound(new { Message = $"Post with ID {id} not found." });
            }
            return Ok(post);
        }

        // POST: api/posts
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // DELETE: api/posts/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound(new { Message = $"Post with ID {id} not found." });
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
