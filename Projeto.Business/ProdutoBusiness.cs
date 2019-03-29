using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository;

namespace Projeto.Business
{
    public class ProdutoBusiness
    {
        private readonly ProdutoRepository repository;

        public ProdutoBusiness()
        {
            repository = new ProdutoRepository();
        }

        public void Cadastrar(Produto produto)
        {
            repository.Insert(produto);
        }

        public void Atualizar(Produto produto)
        {
            repository.Update(produto);
        }

        public void Excluir(int idProduto)
        {
            repository.Delete(idProduto);
        }

        public List<Produto> ObterTodos()
        {
            return repository.GetAll();
        }

        public Produto ObterPorId(int idProduto)
        {
            return repository.GetById(idProduto);
        }
    }
}
