using System.ComponentModel.DataAnnotations;

namespace UdemyJwtApp.Front.Models
{
	public class UserLoginModel
	{
		[Required(ErrorMessage ="Kullanıcı adı gereklidir")]
		public string Username { get; set; } = null!;

		[Required(ErrorMessage ="Şifre gereklidir")]
		public string Password { get; set; } = null!;
    }
}
