using CRUD.Models;
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
            listaPessoas.Add(new Pessoa { Id = 1, Nome = "Pessoa 1", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Id = 2, Nome = "Pessoa 2", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Id = 3, Nome = "Pessoa 3", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Id = 4, Nome = "Pessoa 4", Cpf = 11111111111, Endereco = "endereco 1" });
            listaPessoas.Add(new Pessoa { Id = 5, Nome = "Pessoa 5", Cpf = 11111111111, Endereco = "endereco 1" });
            return View(listaPessoas);
        }

        public IActionResult Cadastrar(int id, string nome, long cpf, string endereco)
        {
            var listaPessoas = new List<Pessoa>();
            listaPessoas.Add(new Pessoa { Id = id, Nome = nome, Cpf = cpf, Endereco = endereco });
            return View();
        }

        public IActionResult Editar(int id, string nome, long cpf, string endereco)
        {
            return View();
        }

        public IActionResult Excluir(int id)
        {   
           
            return View();
        }

        public IActionResult Detalhes(int id)
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