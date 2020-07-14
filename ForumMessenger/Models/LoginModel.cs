using ForumMessenger.Resources;
using System.ComponentModel.DataAnnotations;

namespace ForumMessenger.Models
{
    public class LoginModel
    {
        [Display(Name = "Login", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LoginRequired")]
        public string Login { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}