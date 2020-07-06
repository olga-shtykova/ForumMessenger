using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumMessenger.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("UserSrc")]
        public int? UserIdSrc { get; set; }
        // Ссылка на пользователя отправителя  
        [ForeignKey("UserIdSrc")]
        public User UserSrc { get; set; }

        //[ForeignKey("UserDst")]
        public int? UserIdDst { get; set; }
        // Ссылка на пользователя адресата  
        [ForeignKey("UserIdDst")]
        public User UserDst { get; set; }

        public virtual ICollection<Message> Messages { get; set; }               
        public Chat()
        {
            Messages = new List<Message>();
        }
    }
}