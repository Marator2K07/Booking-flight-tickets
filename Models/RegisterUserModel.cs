using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Project.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан номер документа пользователя")]
        [DataType(DataType.Text)]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Не указан логин пользователя")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Забыли указать пароль для пользователя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают, попробуйте еще")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
