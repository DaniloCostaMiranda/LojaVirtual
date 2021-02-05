using System;
using LVirt.Models;
using X.PagedList;

namespace LVirt.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(int Id);

        Produto ObterProduto(int Id);
        IPagedList<Produto> ObterTodosProdutos(int? pagina, string pesquisa);
    }
}
