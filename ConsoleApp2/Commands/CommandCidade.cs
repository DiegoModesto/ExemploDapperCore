using ConsoleApp2.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp2.Commands
{
    public class CommandCidade
    {
        #region Queries
        private readonly string STRING_CONNECTION = "Server=localhost;Database=DbTest;Uid=sa;Pwd=@123mudar;";
        private readonly string SqlInsertCidade = "INSERT INTO Cidade (Id, Name, EstadoId) VALUES (@Id, @Name, @EstadoId)";
        private readonly string SqlCidade = "SELECT " +
                        "C.Id, " +
                        "C.Name, " +
                        "C.EstadoId, " +
                        "E.Id, " +
                        "E.Name, " +
                        "E.Short " +
                    "FROM Cidade C " +
                    "INNER JOIN Estado E ON E.Id = C.EstadoId;";
        private readonly string SqlCidadePorId = "SELECT " +
                        "C.Id, " +
                        "C.Name, " +
                        "C.EstadoId, " +
                        "E.Id, " +
                        "E.Name, " +
                        "E.Short " +
                    "FROM Cidade C " +
                    "INNER JOIN Estado E ON E.Id = C.EstadoId" +
                    "WHERE C.Id = @Id;";

        #endregion

        /// <summary>
        /// Irá inserir ua nova cidade
        /// </summary>
        /// <param name="estado"></param>
        public void InserirCidade(CidadeEntity cidade)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                _conn.Execute(SqlInsertCidade, cidade);
            }
        }

        /// <summary>
        /// Irá inserir uma lista de estados
        /// </summary>
        public void InserirCidades(IEnumerable<CidadeEntity> cidades)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                _conn.Execute(SqlInsertCidade, cidades);
            }
        }

        /// <summary>
        /// Irá buscar todos os estados
        /// </summary>
        public IEnumerable<CidadeEntity> BuscarTodos()
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                return _conn.Query<CidadeEntity>(SqlCidade);
            }
        }
        public IEnumerable<CidadeEntity> BuscarTodosComFilhos()
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                return _conn.Query<CidadeEntity, EstadoEntity, CidadeEntity>(
                    SqlCidade,
                    (cidade, estado) =>
                    {
                        cidade.EstadoId = estado.Id;
                        cidade.Estado = estado;
                        return cidade;
                    },
                    splitOn: "EstadoId");
            }
        }

        /// <summary>
        /// Irá buscar o Estado pelo ID
        /// </summary>
        public CidadeEntity BuscarPorId(Guid id)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                return _conn.QueryFirstOrDefault<CidadeEntity>(SqlCidadePorId, id);
            }
        }
    }
}
