using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityAPI.Data;
using CommunityAPI.Models;

namespace CommunityAPI.Controllers
{
    [ApiController]
    [Route("api/Community")]
    public class PostController : ControllerBase
    {
        private readonly CommunityDbContext _context;

        public PostController(CommunityDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _context.Post.ToListAsync();
            return Ok(posts);
        }
    }
}
