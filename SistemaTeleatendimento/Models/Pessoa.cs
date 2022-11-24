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
        [MaxLength(12, ErrorMessage = "O campo {0} não pode ser maior que {1} números")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo{0} tem que ter {1} números")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "{0} tem que ter no mínimo {2} caracteres")]
        public string Endereco { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Pessoa()
        {
        }

        public Pessoa(int id, string nome, long cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
