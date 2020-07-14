using ForumMessenger.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ForumMessenger.Models
{
    public class CreateMessageModel
    {
        [Display(Name = "Message", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MessageCannotBeEmpty")]        
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "SrcUserLogin", ResourceType = typeof(Resource))]
        public string SrcUserLogin { get; set; }  // отправитель сообщения

        [Display(Name = "DstUserLogin", ResourceType = typeof(Resource))]
        public string DstUserLogin { get; set; }  // получатель сообщения
    }
}