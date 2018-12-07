using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.NET.Web.Ui.Models;

namespace Mercado.NET.Web.Ui.Services
{
    public interface IComprasService
    {
        object Compra { get; set; }

        Task<IList<Compra>> GetCompras();
        Task<Compra> GetCompra(Guid id);

        Task<Compra> Add(Compra compra);
        Task SaveChangesAsync();

        void Update(Compra compra);
        Task Remove(Compra compra);
    }
}
