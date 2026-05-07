using Microsoft.AspNetCore.Mvc;

namespace VSAProject.API.Features.UpdatePost
{
    [ApiController]
    [Route("api/posts")]
    public class UpdatePostController(UpdatePostHandler handler) : ControllerBase
    {
        private readonly UpdatePostHandler _handler = handler;

        [HttpPut("{id}", Name = "UpdatePost")]
        public async Task<IActionResult> UpdatePost(int Id, UpdatePostRequest postUpdated)
        {
            var post = await _handler.Handle(Id, postUpdated);
            if (post == null)
                return NotFound();
            return Ok(post);
        }
    }
}
