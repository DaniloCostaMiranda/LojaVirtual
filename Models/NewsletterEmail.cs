using System;
using System.ComponentModel.DataAnnotations;
using LVirt.Libraries.Lang;

namespace LVirt.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
    }
}
