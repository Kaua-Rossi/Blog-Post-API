using Microsoft.EntityFrameworkCore;
using VSAProject.API.Common;
using VSAProject.API.Domain;

namespace VSAProject.API.Features.UpdatePost
{
    public class UpdatePostHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<Post?> Handle(int Id, UpdatePostRequest updatedPost)
        {
            var post = await _db.Posts.FirstOrDefaultAsync(p => p.Id == Id);

            if (post == null)
            {
                return post;
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;

            await _db.SaveChangesAsync();
            return post;
        }
    }
}
