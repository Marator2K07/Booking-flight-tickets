using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Project.Models
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
