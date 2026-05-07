using Microsoft.EntityFrameworkCore;
using VSAProject.API.Common;
using VSAProject.API.Features.CreatePost;
using VSAProject.API.Features.DeletePost;
using VSAProject.API.Features.GetPostById;
using VSAProject.API.Features.GetPosts;
using VSAProject.API.Features.UpdatePost;

namespace VSAProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<GetPostsHandler>();
            builder.Services.AddScoped<GetPostByIdHandler>();
            builder.Services.AddScoped<CreatePostHandler>();
            builder.Services.AddScoped<UpdatePostHandler>();
            builder.Services.AddScoped<DeletePostHandler>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
