using Microsoft.AspNetCore.Mvc;

namespace VSAProject.API.Features.DeletePost
{
    [ApiController]
    [Route("api/posts")]
    public class DeletePostController(DeletePostHandler handler) : ControllerBase
    {
        private readonly DeletePostHandler _handler = handler;

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(int Id)
        {
            var result = await _handler.Handle(Id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
