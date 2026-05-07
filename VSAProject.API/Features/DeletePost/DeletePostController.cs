using Microsoft.AspNetCore.Mvc;
using VSAProject.API.Features.GetPostById;

namespace VSAProject.API.Features.DeletePost
{
    [ApiController]
    [Route("api/posts")]
    public class DeletePostController(DeletePostHandler deletePostHandler, GetPostByIdHandler getPostByIdHandler) : ControllerBase
    {
        private readonly GetPostByIdHandler _getPostByIdHandler = getPostByIdHandler;
        private readonly DeletePostHandler _deletePostHandler = deletePostHandler;

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(int Id)
        {
            var post = await _getPostByIdHandler.Handle(Id);

            if (post == null)
            {
                return NotFound();
            }

            await _deletePostHandler.Handle(Id);
            return NoContent();
        }
    }
}
