using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Projeto.Entities;

namespace Projeto.Repository
{
    public class ProdutoRepository
    {
        private readonly string connectionString;

        //ctor + 2x[tab]
        public ProdutoRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["projeto"].ConnectionString;
        }

        public void Insert(Produto produto)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "insert into Produto(Nome, Preco, Quantidade, IdEstoque) "
                          + "values(@Nome, @Preco, @Quantidade, @IdEstoque)";

                conn.Execute(query, produto);
            }
        }

        public void Update(Produto produto)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "update Produto set Nome = @Nome, Preco = @Preco, "
                          + "Quantidade = @Quantidade, IdEstoque = @IdEstoque "
                          + "where IdProduto = @IdProduto";

                conn.Execute(query, produto);
            }
        }

        public void Delete(int idProduto)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "delete from Produto where IdProduto = @IdProduto";

                conn.Execute(query, new { IdProduto = idProduto });
            }
        }

        public List<Produto> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "select * from Produto p inner join Estoque e "
                          + "on e.IdEstoque = p.IdEstoque";

                return conn.Query(query, 
                    (Produto p, Estoque e) =>
                        {
                            p.Estoque = e;
                            return p;
                        },
                    splitOn: "IdEstoque").ToList();
            }
        }

        public Produto GetById(int idProduto)
        {
            using (var conn = new SqlConnection(connectionString))
            {    
                var query = "select * from Produto p inner join Estoque e "
                          + "on e.IdEstoque = p.IdEstoque "
                          + "where p.IdProduto = @IdProduto";

                return conn.Query(query,
                    (Produto p, Estoque e) =>
                    {
                        p.Estoque = e;
                        return p;
                    },
                    new { IdProduto = idProduto },
                    splitOn: "IdEstoque").SingleOrDefault();
            }
        }
    }
}
