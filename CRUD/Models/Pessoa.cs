using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tem que ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(12, ErrorMessage = "O campo {0} não pode ser maior que {1} números")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} tem que ter {1} números")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "{0} tem que ter no mínimo {2} caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo DDD é obrigatório")]
        [MaxLength(4, ErrorMessage = "O campo DDD deve ser Ex: 011")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O campo DDD deve ser Ex: 011")]
        public int DDD_principal { get; set; }

        [Required(ErrorMessage = "O campo Telefone Principal é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo Telefone Principal deve ser Ex: 988776655")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O campo Telefone Principal deve ser Ex: 988776655")]
        public long Tel_principal { get; set; }

        
        [MaxLength(4, ErrorMessage = "O campo DDD deve ser Ex: 011")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O campo DDD deve ser Ex: 011")]
        public int? DDD_secundario { get; set; }

        
        [MaxLength(10, ErrorMessage = "O campo Telefone Secundário deve ser Ex: 988776655")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O campo Telefone Secundário deve ser Ex: 988776655")]
        public long? Tel_secundario { get; set; }
    }
}
