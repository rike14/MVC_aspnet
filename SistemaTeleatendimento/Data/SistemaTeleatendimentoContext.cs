using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTeleatendimento.Models;

namespace SistemaTeleatendimento.Data
{
    public class SistemaTeleatendimentoContext : DbContext
    {
        public SistemaTeleatendimentoContext (DbContextOptions<SistemaTeleatendimentoContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
    }
}
