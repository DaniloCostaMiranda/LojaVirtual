﻿using System;
using Microsoft.AspNetCore.Http;

namespace LVirt.Libraries.Sessao
{
    public class Sessao
    {
        private IHttpContextAccessor _context;
        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

      //CRUD - Cadastrar/Atualizar/Consultar/Deletar - Remover All/Exist
      
        public void Cadastrar(string Key, string Valor)
        {
            _context.HttpContext.Session.SetString(Key, Valor);
        }
        public void Atualizar(string Key, string Valor)
        {
            if (Existe(Key))
            {
                _context.HttpContext.Session.Remove(Key);
            }
            _context.HttpContext.Session.SetString(Key, Valor);
            
        }
        public void Remover(string Key)
        {
            _context.HttpContext.Session.Remove(Key);
        }
        public string Consultar(string Key)
        {
           return _context.HttpContext.Session.GetString(Key);
        }
        public bool Existe(string Key)
        {
         if(_context.HttpContext.Session.GetString(Key) == null)
            {
                return false;
            }
            
                return true;
        }
        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }

    }
}