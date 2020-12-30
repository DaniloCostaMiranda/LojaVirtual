using System;
namespace LVirt.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        // Tipo C = Comum & G = Gerente

        public string Tipo { get; set; }
    }
}
