using Microsoft.AspNetCore.Mvc;
using VSAProject.API.Domain;
using VSAProject.API.Features.GetPostById;
using VSAProject.API.Features.GetPosts;

namespace VSAProject.API.Features.UpdatePost
{
    [ApiController]
    [Route("api/posts")]
    public class UpdatePostController(UpdatePostHandler updatePostHandler, GetPostByIdHandler getPostByIdHandler) : ControllerBase
    {
        private readonly GetPostByIdHandler _getPostByIdHandler = getPostByIdHandler;
        private readonly UpdatePostHandler _updatePostHandler = updatePostHandler;

        [HttpPut("{id}", Name = "UpdatePost")]
        public async Task<IActionResult> UpdatePost(int Id, Post postUpdated)
        {
            if (_getPostByIdHandler.Handle(Id) == null)
            {
                return NotFound();
            }
            if (postUpdated == null) {
                return BadRequest();
            }
            var post = await _updatePostHandler.Handle(Id, postUpdated);
            return Ok(post);
        }
    }
}
