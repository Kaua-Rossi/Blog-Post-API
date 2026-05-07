using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VSAProject.API.Common;
using VSAProject.API.Domain;

namespace VSAProject.API.Features.CreatePost
{
    public class CreatePostHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;
        public async Task<Post> Handle(CreatePostRequest request)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content
            };
            await _db.AddAsync(post);
            await _db.SaveChangesAsync();
            return post;
        }
    }
}
