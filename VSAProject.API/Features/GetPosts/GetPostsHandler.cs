using Microsoft.EntityFrameworkCore;
using VSAProject.API.Common;

namespace VSAProject.API.Features.GetPosts
{
    public class GetPostsHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<List<GetPostsResponse>> Handle()
        {
            var posts = await _db.Posts.ToListAsync();
            return posts.Select(p => new GetPostsResponse(p.Id, p.Title, p.Content)).OrderBy(p => p.Id).ToList();
        }
    }
}
