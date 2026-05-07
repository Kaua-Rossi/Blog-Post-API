using Microsoft.AspNetCore.Mvc;

namespace VSAProject.API.Features.GetPostById
{
    [ApiController]
    [Route("api/posts")]
    public class GetPostByIdController(GetPostByIdHandler handler) : ControllerBase
    {
        private readonly GetPostByIdHandler _handler = handler;
        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _handler.Handle(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }
    }
}
