using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTeleatendimento.Data;
using SistemaTeleatendimento.Models;

namespace SistemaTeleatendimento.Controllers
{
    public class PessoasController : Controller
    {
        private readonly SistemaTeleatendimentoContext _context;

        public Pessoa Pessoa { get; private set; }

        public PessoasController(SistemaTeleatendimentoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pessoaViewModel = new PessoaViewModel();
            pessoaViewModel.Pessoa = await _context.Pessoa.FindAsync(id);
            pessoaViewModel.Endereco = await _context.Endereco.Where(t => t.PessoaId == id).FirstOrDefaultAsync();
            pessoaViewModel.TelefonePrimario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 1).FirstOrDefaultAsync();
            pessoaViewModel.TelefoneSecundario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 2).FirstOrDefaultAsync();

            if (pessoaViewModel.Pessoa == null)
            {
                return NotFound();
            }
            return View(pessoaViewModel);
        }
        // GET: Pessoas/Create
        public IActionResult Create()
        {           
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid) return View(pessoaViewModel);

            _context.Pessoa.Add(pessoaViewModel.Pessoa);

            var pessoa = pessoaViewModel.Pessoa;

            pessoaViewModel.Endereco.Pessoa = pessoa;
            _context.Endereco.Add(pessoaViewModel.Endereco);

            pessoaViewModel.TelefonePrimario.TipoId = 1;
            pessoaViewModel.TelefoneSecundario.TipoId = 2;

            pessoaViewModel.TelefonePrimario.Pessoa = pessoa;
            pessoaViewModel.TelefoneSecundario.Pessoa = pessoa;
            

            var telefones = new List<Telefone>();
            telefones.Add(pessoaViewModel.TelefonePrimario);
            telefones.Add(pessoaViewModel.TelefoneSecundario);
            
            _context.Telefone.AddRange(telefones);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pessoaViewModel = new PessoaViewModel();
            pessoaViewModel.Pessoa = await _context.Pessoa.FindAsync(id);
            pessoaViewModel.Endereco = await _context.Endereco.Where(t => t.PessoaId == id).FirstOrDefaultAsync();
            pessoaViewModel.TelefonePrimario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 1).FirstOrDefaultAsync();
            pessoaViewModel.TelefoneSecundario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 2).FirstOrDefaultAsync();

            if (pessoaViewModel.Pessoa == null)
            {
                return NotFound();
            }
            return View(pessoaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PessoaViewModel pessoaViewModel)
        {
            pessoaViewModel.Pessoa.Id = id;
            if (ModelState.IsValid)
            {
                try
                {
                    var pessoa = pessoaViewModel.Pessoa;
                    _context.Pessoa.Update(pessoa);

                    pessoaViewModel.Endereco.Pessoa = pessoa;
                    pessoaViewModel.TelefonePrimario.Pessoa = pessoa;
                    pessoaViewModel.TelefoneSecundario.Pessoa = pessoa;

                    pessoaViewModel.TelefonePrimario.TipoId = 1;
                    pessoaViewModel.TelefoneSecundario.TipoId = 2;

                    _context.Endereco.Update(pessoaViewModel.Endereco);
                    _context.Telefone.Update(pessoaViewModel.TelefonePrimario);
                    _context.Telefone.Update(pessoaViewModel.TelefoneSecundario);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.Pessoa.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pessoaViewModel = new PessoaViewModel();
            pessoaViewModel.Pessoa = await _context.Pessoa.FindAsync(id);
            pessoaViewModel.Endereco = await _context.Endereco.Where(t => t.PessoaId == id).FirstOrDefaultAsync();
            pessoaViewModel.TelefonePrimario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 1).FirstOrDefaultAsync();
            pessoaViewModel.TelefoneSecundario = await _context.Telefone.Where(t => t.PessoaId == id && t.TipoId == 2).FirstOrDefaultAsync();

            if (pessoaViewModel.Pessoa == null)
            {
                return NotFound();
            }
            return View(pessoaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefones = await _context.Telefone.Where(t => t.PessoaId == id).ToListAsync();
            var pessoa = await _context.Pessoa.FindAsync(id);
            telefones.ForEach(t => _context.Telefone.Remove(t));
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
