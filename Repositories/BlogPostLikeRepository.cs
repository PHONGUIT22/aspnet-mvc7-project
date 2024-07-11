using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostLikeRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

		public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike bLogPostLike)
		{
            await bloggieDbContext.BlogPostLike.AddAsync(bLogPostLike);
            await bloggieDbContext.SaveChangesAsync();
            return bLogPostLike;
		}

		public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
		{
		   return	await bloggieDbContext.BlogPostLike.Where(x=>x.BlogPostId == blogPostId).ToListAsync();
		}

		public async Task<int> GetTotalLikes(Guid blogPostId)
        {
           return await bloggieDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
