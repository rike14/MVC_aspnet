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
            listaPessoas.Add(new Pessoa { Id = 1, Nome = "José Roberto", Cpf = 10788936251, Endereco = "Rua Dos Jardins, nº: 431, Bairro: Jardim Primavera, Mauá-SP", DDD_principal = 011, Tel_principal = 987540321, DDD_secundario = 011, Tel_secundario = 997034421 });
            listaPessoas.Add(new Pessoa { Id = 2, Nome = "Maria da Silva", Cpf = 20896310523, Endereco = "Avenida Brasil, nº: 1321, Bairro: Campo Grande, Rio de Janeiro-RJ", DDD_principal = 021, Tel_principal = 988167890 });
            listaPessoas.Add(new Pessoa { Id = 3, Nome = "João Paulo", Cpf = 03564232133, Endereco = "Rua Canário, nº: 70, Bairro: Vila Nova, Barueri-SP" , DDD_principal = 011, Tel_principal = 987660911, DDD_secundario = 011, Tel_secundario = 991732234});
            return View(listaPessoas);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var pessoa = new Pessoa { Id = id, Nome = "João Paulo", Cpf = 03564232133, Endereco = "Rua Canário, nº: 70, Bairro: Vila Nova, Barueri-SP", DDD_principal = 011, Tel_principal = 987660911, DDD_secundario = 011, Tel_secundario = 991732234 };
            return View(pessoa);
        }

        public IActionResult Excluir(int id)
        {
            var pessoa = new Pessoa { Id = id, Nome = "Maria da Silva", Cpf = 20896310523, Endereco = "Avenida Brasil, nº: 1321, Bairro: Campo Grande, Rio de Janeiro-RJ", DDD_principal = 021, Tel_principal = 988167890 };
            return View(pessoa);
        }

        public IActionResult Detalhes(int id)
        {   
            var pessoa = new Pessoa{ Id = id, Nome = "José Roberto", Cpf = 10788936251, Endereco = "Rua Dos Jardins, nº: 431, Bairro: Jardim Primavera, Mauá-SP", DDD_principal = 011, Tel_principal = 987540321, DDD_secundario = 011, Tel_secundario = 997034421 };
            return View(pessoa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}