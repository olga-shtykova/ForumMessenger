using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForumMessenger.Resources;

namespace ForumMessenger.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        public string Surname { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resource))]
        public string Login { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Display(Name = "Role", ResourceType = typeof(Resource))]
        public string Role { get; set; }

        [InverseProperty("UserSrc")]
        public ICollection<Chat> ChatsSrc { get; set; }

        [InverseProperty("UserDst")]
        public virtual ICollection<Chat> ChatsDst { get; set; }

        public User()
        {
            ChatsSrc = new List<Chat>();
            ChatsDst = new List<Chat>();
        }
    }
}