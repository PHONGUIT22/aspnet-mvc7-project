using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
	public interface IBlogPostComentRepository
	{
		Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

		Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
	}
}
