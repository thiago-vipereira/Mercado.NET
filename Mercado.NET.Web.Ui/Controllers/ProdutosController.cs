using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercado.NET.Web.Ui.Data;
using Mercado.NET.Web.Ui.Models;
using Mercado.NET.Web.Ui.Services;
using Microsoft.AspNetCore.Authorization;

namespace Mercado.NET.Web.Ui.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            IList<Produto> list = await _service.GetProdutos();
            return View(list);
        }

        public async Task<IActionResult> Nome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return RedirectToAction(nameof(Index));

            var list = await _service.GetProdutos(nome);

            return View(nameof(Index), list);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _service.GetProduto(id.Value);
                
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<Produto> DetailsModal(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var produto = await _service.GetProduto(id.Value);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cadastro,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = Guid.NewGuid();
                await _service.Add(produto);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _service.GetProduto(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Cadastro,Preco")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(produto);
                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _service.GetProduto(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _service.GetProduto(id);
            await _service.Remove(produto);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return _service.GetProduto(id) != null;
        }
    }
}
