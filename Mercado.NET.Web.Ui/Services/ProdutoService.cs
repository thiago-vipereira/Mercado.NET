using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.NET.Web.Ui.Data;
using Mercado.NET.Web.Ui.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.NET.Web.Ui.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object Produtos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Produto> Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public Task<Produto> GetProduto(Guid id)
        {
            return _context.Produtos.FindAsync(id);
        }

        public Task<Produto> GetProdutoAjax(int id)
        {
            return _context.Produtos.FindAsync(id);
        }

        public async Task<IList<Produto>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<IList<Produto>> GetProdutos(string nome)
        {
            return await _context.Produtos
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task Remove(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
        }
    }
}
