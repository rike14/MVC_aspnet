﻿namespace CRUD.Models

public class PessoaModel
{
    protected int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public List<Telefone> Telefones { get; set; }
}