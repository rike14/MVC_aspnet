namespace SistemaTeleatendimento.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logadouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public Endereco()
        {

        }

        public Endereco(string logadouro, int numero, int cep, string bairro, string cidade, string estado, Pessoa pessoa)
        {
            Logadouro = logadouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pessoa = pessoa;
        }

        public override string ToString()
        {
            return $"{Logadouro}, nº {Numero}, {Complemento}, {Bairro}, {Cidade} - {Estado} / {Cep}";
        }
    }
}
