﻿using System;
using LVirt.Models;
using Microsoft.EntityFrameworkCore;
namespace LVirt.Database
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext (DbContextOptions<LojaVirtualContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
