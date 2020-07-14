using ForumMessenger.Resources;
using System.ComponentModel.DataAnnotations;

namespace ForumMessenger.Models
{
    public class RegisterModel
    {
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NameRequired")]        
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NameLengthInvalid")]
        [RegularExpression(@"^([A-ZА-Яa-zа-я]+)$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "NameInvalid")]
        public string Name { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "SurnameRequired")]        
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "SurnameLengthInvalid")]
        [RegularExpression(@"^([A-ZА-Яa-zа-я]+)$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "SurnameInvalid")]
        public string Surname { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LoginRequired")]        
        [RegularExpression(@"^([a-z0-9]){4,8}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LoginInvalid")]
        public string Login { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailRequired")]        
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        public string Role { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRequired")]        
        [StringLength(18, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordLengthInvalid", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordRequired")]        
        [Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "PasswordMustMatch")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}