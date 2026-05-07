using Microsoft.AspNetCore.Mvc;

namespace VSAProject.API.Features.GetPosts
{
    [ApiController]
    [Route("api/posts")]
    public class GetPostsController(GetPostsHandler handler) : ControllerBase
    {
        private readonly GetPostsHandler _handler = handler;
        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> GetPosts() =>
            Ok(await _handler.Handle());
    }
}
