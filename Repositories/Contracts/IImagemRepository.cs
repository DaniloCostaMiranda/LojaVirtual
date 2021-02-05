using System;
using LVirt.Models;

namespace LVirt.Repositories.Contracts
{
    public interface IImagemRepository
    {
        void Cadastrar(Imagem imagem);
        
        void Excluir(int Id);
        void ExcluirImagensDoProduto(int ProdutoId);
    }
}
