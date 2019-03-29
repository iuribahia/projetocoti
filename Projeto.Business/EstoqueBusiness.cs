using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //importando
using Projeto.Repository; //importando

namespace Projeto.Business
{
    public class EstoqueBusiness
    {
        //atributo..
        private readonly EstoqueRepository repository;

        //construtor
        public EstoqueBusiness()
        {
            //inicializando o atributo
            repository = new EstoqueRepository();
        }

        public void Cadastrar(Estoque estoque)
        {
            repository.Insert(estoque);
        }

        public void Atualizar(Estoque estoque)
        {
            repository.Update(estoque);
        }

        public void Excluir(int idEstoque)
        {
            repository.Delete(idEstoque);
        }

        public List<Estoque> ObterTodos()
        {
            return repository.GetAll();
        }

        public Estoque ObterPorId(int idEstoque)
        {
            return repository.GetById(idEstoque);
        }
    }
}
