using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LVirt.Libraries.Lang;

namespace LVirt.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        //TODO - criar validação - nome categoria unico no banco de dados.
        public string Nome { get; set; }

        //Nome:Telefone
        //Slug:Telefone-sem-fio
        //URL Normal: www.lojavirtual.com.br/categoria/5
        //URL Amigavel e Slug
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        //Auto-relacionamento
        //1 - Informatica - P:Null
        // 2 - Mouse - P:1
        // 3 --Mouse sem fio - P:2
        // 4 --Mouse Gamer - P:2

        [Display (Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
         
    }
}
