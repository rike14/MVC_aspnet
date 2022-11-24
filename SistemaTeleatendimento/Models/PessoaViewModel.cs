using System;
using System.Collections.Generic;

namespace SistemaTeleatendimento.Models
{
    public class PessoaViewModel
    {
        public Pessoa Pessoa { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        public Telefone Telefone { get; set; }
        public ICollection<TipoTelefone> TiposTelefone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }

        public string GetPropsTelefone()
        {
            var prop = "";
            var t = new Telefone();
            if (prop == nameof(Telefone.Ddd)) return nameof(Telefone.Ddd);
            if (prop == nameof(Telefone.Numero)) return nameof(Telefone.Numero);

            throw new ArgumentException("Propriedade não encontrada");
        }
        public string teste()
        {
            return "12";
        }
    }
}
