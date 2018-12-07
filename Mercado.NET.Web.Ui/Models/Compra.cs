using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.NET.Web.Ui.Models
{
    public class Compra
    {
        public Guid Id { get; set; }

        [Display(Name = "ID do usuário")]
        public string UsuarioId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        public List<Produto> Itens { get; set; }
    }
}
