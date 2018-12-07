using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.NET.Web.Ui.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        [StringLength(100, ErrorMessage = "O nome tem que estar entre 2 e 100 caracteres", MinimumLength = 2)]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Inclusão")]
        public DateTime Cadastro { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}",
           ApplyFormatInEditMode = true,
           NullDisplayText = "Sem preço")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
