using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[MinLength(6,ErrorMessage ="Mat khau phai 6 ky tu tro len =)")]
		public string Password { get; set; }

	}
}
