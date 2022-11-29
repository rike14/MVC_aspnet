using Microsoft.EntityFrameworkCore;
using SistemaTeleatendimento.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTeleatendimento.Models
{
    public class PessoaViewModel
    {
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
        public Telefone TelefonePrimario { get; set; }
        public Telefone TelefoneSecundario { get; set; }
        public ICollection<TipoTelefone> TiposTelefone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
