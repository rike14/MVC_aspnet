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
            dynamic mymodel = new ExpandoObject();
            var PessoaViewModel = new PessoaViewModel();
            PessoaViewModel.Pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == id);
            PessoaViewModel.Telefones = await _context.Telefone.Where(t => t.PessoaId == id).ToListAsync();
            if (PessoaViewModel.Pessoa == null)
            {
                return NotFound();
            }

            return View(PessoaViewModel);
        }

        // GET: Pessoas/Create
        public async Task<IActionResult> Create()
        {
            var PessoaViewModel = new PessoaViewModel();
            PessoaViewModel.TiposTelefone = await _context.TipoTelefone.ToListAsync();
            foreach (TipoTelefone item in PessoaViewModel.TiposTelefone)
            {
                PessoaViewModel.Telefones.Add(new Telefone(item));
            }

            return View(PessoaViewModel);
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaViewModel pessoaViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaViewModel.Pessoa);
                _context.Add(pessoaViewModel.Telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Endereco")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
