using System;
using System.ComponentModel.DataAnnotations;

namespace ForumMessenger.Models
{
    public class CreateMessageModel
    {       
        [Required(ErrorMessage ="Сообщение не может быть пустым!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string SrcUserLogin { get; set; }  // отправитель сообщения
        public string DstUserLogin { get; set; }  // получатель сообщения
    }
}