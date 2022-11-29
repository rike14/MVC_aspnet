using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaTeleatendimento.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tem que ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Cpf { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Pessoa()
        {
        }

        public Pessoa(int id, string nome, long cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}
