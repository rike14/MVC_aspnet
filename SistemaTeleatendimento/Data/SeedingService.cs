using SistemaTeleatendimento.Models;
using System.Linq;

namespace SistemaTeleatendimento.Data
{
    public class SeedingService
    {
        private SistemaTeleatendimentoContext _context;

        public SeedingService(SistemaTeleatendimentoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Pessoa.Any() || _context.Telefone.Any() || _context.TipoTelefone.Any()) return;

            var TipoTelefonePrincipal = new TipoTelefone(1, "Principal");
            var TipoTelefoneSegundario = new TipoTelefone(2, "Segundario");
            _context.TipoTelefone.AddRange(TipoTelefonePrincipal,TipoTelefoneSegundario);

            for(int i = 1; i < 5; i++)
            {
                var pessoa = new Pessoa(i, "Pessoa " + i, 10020030040 + i, "Rua " + i);
                _context.Pessoa.Add(pessoa);
                _context.Telefone.Add(
                                      new Telefone(
                                        i, 900000000 + i, 10 + i,
                                        TipoTelefonePrincipal, 
                                        pessoa
                                      )
                                     );
            }
            _context.SaveChanges();
        }
    }
}
