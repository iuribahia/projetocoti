using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Projeto.Entities;
using System.Configuration;

namespace Projeto.Repository
{
    public class EstoqueRepository
    {
        //atributo..
        //readonly -> só permite que o atributo seja
        //inicializado no método construtor da classe
        private readonly string connectionString;

        //construtor -> ctor + 2x[tab]
        public EstoqueRepository()
        {
            //inicializando o atributo
            connectionString = ConfigurationManager
                .ConnectionStrings["projeto"].ConnectionString;
        }

        //método para inserir um estoque na base de dados
        public void Insert(Estoque estoque)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "insert into Estoque(Nome, Descricao) "
                          + "values(@Nome, @Descricao)";

                conn.Execute(query, estoque);
            }
        }

        //método para atualizar um estoque na base de dados
        public void Update(Estoque estoque)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "update Estoque set Nome = @Nome, Descricao = @Descricao "
                          + "where IdEstoque = @IdEstoque";

                conn.Execute(query, estoque);
            }
        }

        //método para excluir um estoque na base de dados
        public void Delete(int idEstoque)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "delete from Estoque where IdEstoque = @IdEstoque";

                conn.Execute(query, new { IdEstoque = idEstoque });
            }
        }

        //método para consultar todos os estoques
        public List<Estoque> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "select * from Estoque";

                return conn.Query<Estoque>(query).ToList();
            }
        }

        //método para retornar 1 estoque pelo id
        public Estoque GetById(int idEstoque)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "select * from Estoque where IdEstoque = @IdEstoque";

                return conn.QuerySingleOrDefault<Estoque>
                        (query, new { IdEstoque = idEstoque });
            }
        }

    }
}
