﻿using CRUD.Models;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class PessoasController : Controller
    {
        private readonly ILogger<PessoasController> _logger;

        public PessoasController(ILogger<PessoasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listaPessoas = new List<Pessoa>();
            listaPessoas.Add(new Pessoa { Nome = "Pessoa 1", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Nome = "Pessoa 2", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Nome = "Pessoa 3", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Nome = "Pessoa 4", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Nome = "Pessoa 5", Cpf = 11111111111, Endereco = "endereco 1" });
            return View(listaPessoas);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}