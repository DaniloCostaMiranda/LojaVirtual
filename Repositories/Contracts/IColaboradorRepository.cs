using System;
using System.Collections.Generic;
using LVirt.Models;
using X.PagedList;

namespace LVirt.Repositories.Contracts
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);

        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void Excluir(int Id);

        Colaborador ObterColaborador(int Id);
       
        IPagedList<Colaborador> ObterTodosColaboradores(int? pagina);
    }
}
