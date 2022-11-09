using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CRUD.Views.Pessoas
{
    public class IndexModel : PageModel
    {
        public List<PessoaInfo> listaPessoas = new List<PessoaInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString)) 
                { 
                    connection.Open();
                    String sql = "SELECT * FROM pessoa";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PessoaInfo pessoaInfo = new PessoaInfo();
                                pessoaInfo.id = "" + reader.GetInt32(0);
                                pessoaInfo.nome = reader.GetString(1);
                                pessoaInfo.cpf = reader.GetString(2);
                                pessoaInfo.endereco= reader.GetString(3);

                                listaPessoas.Add(pessoaInfo);  
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public class PessoaInfo
        {
            public String id;
            public String nome;
            public String cpf;
            public String endereco;
        }
    }
}
