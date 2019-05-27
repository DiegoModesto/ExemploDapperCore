using ConsoleApp2.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp2.Commands
{
    public class CommandEstado
    {
        #region Queries
        private readonly string STRING_CONNECTION = "Server=localhost;Database=DbTest;Uid=sa;Pwd=@123mudar;";
        private readonly string SqlUpdateEstado = "UPDATE dbo.Estado SET Name = @Name, Short = @Short WHERE Id = @Id";
        private readonly string SqlEstados = "SELECT " +
                                                "Id, " +
                                                "Name, " +
                                                "Short " +
                                            "FROM Estado;";
        private readonly string SqlEstadoPorId = "SELECT " +
                                                    "Id, " +
                                                    "Name, " +
                                                    "Short " +
                                                "FROM Estado " +
                                                "WHERE Id = @Id;";
        private readonly string SqlInserEstado = "INSERT INTO dbo.Estado (Id, Name, Short) " +
                                                    "VALUES( " +
                                                        "@Id, " +
                                                        "@Name, " +
                                                        "@Short " +
                                                    ")";
        #endregion

        /// <summary>
        /// Irá inserir um novo estado
        /// </summary>
        /// <param name="estado"></param>
        public void InserirEstado(EstadoEntity estado)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                _conn.Execute(SqlInserEstado, estado);
            }
        }

        /// <summary>
        /// Irá inserir uma lista de estados
        /// </summary>
        public void InserirEstados(IEnumerable<EstadoEntity> estados)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                _conn.Execute(SqlInserEstado, estados);
            }
        }

        /// <summary>
        /// Irá buscar todos os estados
        /// </summary>
        public IEnumerable<EstadoEntity> BuscarTodos()
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                return _conn.Query<EstadoEntity>(SqlEstados);
            }
        }

        /// <summary>
        /// Irá buscar o Estado pelo ID
        /// </summary>
        public EstadoEntity BuscarPorId(Guid id)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                return _conn.QueryFirstOrDefault<EstadoEntity>(SqlEstadoPorId, new { @Id = id } );
            }
        }

        /// <summary>
        /// Irá atualizar um estado de acordo com seu objeto.
        /// NÂO ESQUECER DE PASSAR O ID.
        /// </summary>
        public void AtualizarEstado(EstadoEntity estado)
        {
            using (SqlConnection _conn = new SqlConnection(STRING_CONNECTION))
            {
                _conn.Execute(SqlUpdateEstado, estado);
            }
        }
    }
}
