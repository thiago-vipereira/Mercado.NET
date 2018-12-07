using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercado.NET.Web.Ui.Data;
using Mercado.NET.Web.Ui.Models;
using Microsoft.AspNetCore.Authorization;

namespace Mercado.NET.Web.Ui.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly Services.IComprasService _service;

        public ComprasController(Services.IComprasService service)
        {
            _service = service;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            IList<Compra> list = await _service.GetCompras();
            return View(list);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compra compra = await _service.GetCompra(id.Value);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,DataVenda")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.Id = Guid.NewGuid();
                await _service.Add(compra);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _service.GetCompra(id.Value);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UsuarioId,DataVenda")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(compra);
                    await _service.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _service.GetCompra(id.Value);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var compra = await _service.GetCompra(id);
            await _service.Remove(compra);
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(Guid id)
        {
            return _service.GetCompra(id) != null;
        }
    }
}
