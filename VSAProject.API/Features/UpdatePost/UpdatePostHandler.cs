
using Microsoft.EntityFrameworkCore;
using VSAProject.API.Common;
using VSAProject.API.Domain;

namespace VSAProject.API.Features.UpdatePost
{
    public class UpdatePostHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<Post> Handle(int Id, Post updatedPost)
        {
            var post = _db.Posts.First(p => p.Id == Id);
            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            await _db.SaveChangesAsync();
            return post;
        }
    }
}
