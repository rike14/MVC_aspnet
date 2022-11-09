using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CRUD.Views.Pessoas.IndexModel;

namespace CRUD.Views.Pessoas
{
    public class CadastrarModel : PageModel
    {
        public PessoaInfo pessoaInfo = new PessoaInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            pessoaInfo.nome = Request.Form["nome"];
            pessoaInfo.cpf = Request.Form["cpf"];
            pessoaInfo.endereco = Request.Form["endereco"];

            if(pessoaInfo.nome.Length == 0 || pessoaInfo.cpf.Length == 0 || pessoaInfo.endereco.Length == 0 ) 
            {
                errorMessage = "Todos os campos são obrigatórios";
                return;
            }

            pessoaInfo.nome = "";
            pessoaInfo.cpf = "";
            pessoaInfo.endereco = "";
            successMessage = "Cadastro efetuado com sucesso!";
        }
    }
}
