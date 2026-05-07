using VSAProject.API.Common;

namespace VSAProject.API.Features.DeletePost
{
    public class DeletePostHandler(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<bool> Handle(int id)
        {
            var post = _db.Posts.First(p => p.Id == id);
            if (post == null)
            {
                return false;
            }
            _db.Remove(post);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
