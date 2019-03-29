using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //importando
using System.Web.Mvc; //importando

namespace Projeto.Presentation.Models
{
    public class ProdutoCadastroViewModel
    {
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto")]
        public string Nome { get; set; }

        [Range(0.01, 99999, ErrorMessage = "Por favor, informe um valor entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto")]
        public decimal Preco { get; set; }

        [Range(1, 99999, ErrorMessage = "Por favor, informe um valor entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estoque do produto")]
        public int IdEstoque { get; set; }

        public List<SelectListItem> Estoques { get; set; }
    }
}