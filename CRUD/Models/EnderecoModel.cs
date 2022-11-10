namespace CRUD.Models
{
    public class EnderecoModel
    {
        protected int Id { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
