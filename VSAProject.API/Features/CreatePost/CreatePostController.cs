using Microsoft.AspNetCore.Mvc;

namespace VSAProject.API.Features.CreatePost
{
    [ApiController]
    [Route("api/posts")]
    public class CreatePostController : ControllerBase
    {
        private readonly CreatePostHandler _handler;

        public CreatePostController(CreatePostHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            var post = await _handler.Handle(request);
            return CreatedAtRoute("GetPostById", new { id = post.Id }, post);
        }
    }
}
