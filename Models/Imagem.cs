using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVirt.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Caminho { get; set; }

        //Banco de dados
        public int ProdutoId { get; set; }

        //POO
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
    }
}
