using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Estoque
    {
        //propriedades -> prop + 2x[tab]
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //Relacionamento de Associação
        public List<Produto> Produtos { get; set; }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"{IdEstoque}, {Nome}, {Descricao}";
        }
    }
}
