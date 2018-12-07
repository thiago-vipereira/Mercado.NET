using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.NET.Web.Ui.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado.NET.Web.Ui.Services
{
    public class ComprasService : IComprasService
    {
        private readonly Data.ApplicationDbContext _context;

        public ComprasService(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public object Compra { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Compra> Add(Compra compra)
        {
           _context.Compra.Add(compra);
            await _context.SaveChangesAsync();

            return compra;
        }

        public Task<Compra> GetCompra(Guid id)
        {
            return _context.Compra.FindAsync(id);
        }

        public async Task<IList<Compra>> GetCompras()
        {
            return await _context.Compra.ToListAsync();
        }

        public async Task Remove(Compra compra)
        {
            _context.Compra.Remove(compra);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Compra compra)
        {
            _context.Compra.Update(compra);
        }
    }
}
