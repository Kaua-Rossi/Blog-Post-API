using VSAProject.API.Common;

namespace VSAProject.API.Features.DeletePost
{
    public class DeletePostHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task Handle(int id)
        {
            var post = _db.Posts.First(p => p.Id == id);
            _db.Remove(post);
            await _db.SaveChangesAsync();
        }
    }
}
