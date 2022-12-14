using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaTeleatendimento.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public int? Numero { get; set; }
        public int? Ddd { get; set; }
        public TipoTelefone Tipo { get; set; }
        public int TipoId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public Telefone()
        {
        }
        public Telefone(int id, int numero, int ddd, TipoTelefone tipo, Pessoa pessoa)
        {
            Id = id;
            Numero = numero;
            Ddd = ddd;
            Tipo = tipo;
            Pessoa = pessoa;
        }
        public Telefone(TipoTelefone tipo)
        {
            Tipo = tipo;
        }

        public override string ToString()
        {
            if (Numero == null || Ddd == null) return "";
            return $"({Ddd}) {Numero}";
        }
    }
}
