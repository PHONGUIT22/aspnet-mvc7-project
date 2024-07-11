using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		[MinLength(6,ErrorMessage ="lam on nhap mat khau tre 6 ky tu")]
		public string Password { get; set; }

		public string? ReturnUrl { get; set; }
	}
}
