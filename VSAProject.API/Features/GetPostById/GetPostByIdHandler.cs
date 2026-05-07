using Microsoft.EntityFrameworkCore;
using VSAProject.API.Common;
using VSAProject.API.Domain;

namespace VSAProject.API.Features.GetPostById
{
    public class GetPostByIdHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<Post> Handle(int id) =>
            await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }
}
