namespace CRUD.Models
{
    public class Telefone
    {
        protected int Id { get; set; }
        public int Numero { get; set; }
        public int Ddd { get; set; }
        public TipoTelefone Tipo { get; set; }

    }
}
