using VSAProject.API.Common;
using VSAProject.API.Domain;

namespace VSAProject.API.Features.GetPostById
{
    public class GetPostByIdHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<Post> Handle(int id) =>
            _db.Posts.FirstOrDefault(p => p.Id == id);
    }
}
