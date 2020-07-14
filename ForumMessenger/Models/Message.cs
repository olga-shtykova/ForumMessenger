using System;
using System.ComponentModel.DataAnnotations;

namespace ForumMessenger.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime Date { get; set; }

        // Это свойство будет использоваться как внешний ключ         
        public int? ChatId { get; set; }

        // Ссылка на чат        
        public Chat Chat { get; set; }
        
    }
}