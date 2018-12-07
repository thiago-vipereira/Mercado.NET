using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.NET.Web.Ui.Models
{
    public class ProdutoPreco
    {
        public Guid Id { get; set; }
        public DateTime Inclusao { get; set; }
        public double Preco { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
