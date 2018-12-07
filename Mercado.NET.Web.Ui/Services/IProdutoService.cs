using Mercado.NET.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.NET.Web.Ui.Services
{
    public interface IProdutoService
    {
        Task<IList<Produto>> GetProdutos();
        Task<IList<Produto>> GetProdutos(string nome);
        Task<Produto> GetProduto(Guid id);

        Task<Produto> GetProdutoAjax(int id);

        Task<Produto> Add(Produto produto);
        Task SaveChangesAsync();

        void Update(Produto produto);
        Task Remove(Produto produto);
    }
}
