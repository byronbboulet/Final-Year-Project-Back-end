using MentalHealthAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MentalHealthAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentalHealthPostController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<MentalHealthPostController> _logger;

        public MentalHealthPostController(DataContext context, ILogger<MentalHealthPostController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // gets all posts from the my sql database, this is the _context.posts, look for Data/DataController.cs
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPost()
        {
            _logger.LogInformation("Fetching all posts.");
            return Ok(await _context.posts.ToListAsync());
        }

        // creates a post and saves it to the my sql database, this is the _context.posts, look for Data/DataController.cs
        [HttpPost]
        public async Task<ActionResult<List<Post>>> CreatePost(Post post)
        {
            _logger.LogInformation($"Creating Post: {post.PostTitle} by {post.Username}"); // Log creation
            _context.posts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(await _context.posts.ToListAsync());
        }

        // updates a post, then saves changes to the my sql database, this is the _context.posts, look for Data/DataController.cs
        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(Post post)
        {
            var dbPost = await _context.posts.FindAsync(post.Id); // Note the capital 'P' in Posts
            if (dbPost == null)
            {
                _logger.LogWarning($"Update failed. Post with ID {post.Id} not found."); // Log warning
                return BadRequest("Post Not Found");
            }

            _logger.LogInformation($"Updating Post: {post.PostTitle} by {post.Username}"); // Log updating action
            // Update fields
            dbPost.PostTitle = post.PostTitle;
            dbPost.PostLabel = post.PostLabel;
            dbPost.PostMediaUri = post.PostMediaUri;
            dbPost.PostTime = post.PostTime;
            dbPost.Likes = post.Likes;
            dbPost.Comments = post.Comments;

            await _context.SaveChangesAsync();
            return Ok(await _context.posts.ToListAsync());
        }

        // deletes a post, then saves changes to the my sql database, this is the _context.posts, look for Data/DataController.cs
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var dbPost = await _context.posts.FindAsync(id);
            if(dbPost == null)
            {
                return BadRequest("Post Not Found");
            }
            _context.posts.Remove(dbPost);
            await _context.SaveChangesAsync();
            return Ok(await _context.posts.ToListAsync());
        }   
    }
}
