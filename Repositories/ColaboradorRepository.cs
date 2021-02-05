using System;
using System.Collections.Generic;
using System.Linq;
using LVirt.Database;
using LVirt.Models;
using LVirt.Models.Constants;
using LVirt.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using X.PagedList;

namespace LVirt.Repositories
{


    public class ColaboradorRepository : IColaboradorRepository
    {
        private IConfiguration _conf;
        private LojaVirtualContext _banco;
        public ColaboradorRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Colaborador colaborador)
        {

            //TODO nome, tipo, email
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(a => a.Senha).IsModified = false;
           
            _banco.SaveChanges();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            //TODO - senha
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(a => a.Nome).IsModified = false;
            _banco.Entry(colaborador).Property(a => a.Email).IsModified = false;
            _banco.Entry(colaborador).Property(a => a.Tipo).IsModified = false;

            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Colaborador colaborador = ObterColaborador(Id);
            _banco.Remove(colaborador);
            _banco.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public List<Colaborador> ObterColaboradorPorEmail(string email)
        {
            return _banco.Colaboradores.Where(a=> a.Email == email).AsNoTracking().ToList();
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            int RegistroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int NumeroPagina = pagina ?? 1;
            return _banco.Colaboradores.Where(a => a.Tipo != ColaboradorTipoConstant.Gerente).ToPagedList<Colaborador>(NumeroPagina, RegistroPorPagina);
        }

    }
   
}