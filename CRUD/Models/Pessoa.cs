﻿namespace CRUD.Models
{
    public class Pessoa
    {
        protected int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Endereco { get; set; }
        //public List<Telefone> Telefones { get; set; }
    }
}