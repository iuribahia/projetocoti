using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Produto
    {
        //propriedades -> prop + 2x[tab]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int IdEstoque { get; set; }

        //Relacionamento de Associação (TER)
        public Estoque Estoque { get; set; }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"{IdProduto}, {Nome}, {Preco}, {Quantidade}";
        }
    }
}
