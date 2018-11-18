using CRUDUsandoMVCeADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUsandoMVCeADO.Repository
{
    public class ClienteRepository : AbstractRepository<Clientes, int>
    {
        ///<summary>Exclui uma pessoa pela entidade
        ///<param name="entity">Referência de Clientes que será excluída.</param>
        ///</summary>
        public override void Delete(Clientes entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Clientes Where Codigocliente=@Codigocliente";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigocliente", entity.CodigoCliente);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Exclui uma pessoa pelo ID
        ///<param name="id">Codigocliente do registro que será excluído.</param>
        ///</summary>
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Clientes Where Codigocliente=@Codigocliente";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigocliente", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Obtém todas as pessoas
        ///<returns>Retorna as pessoas cadastradas.</returns>
        ///</summary>
        public override List<Clientes> GetAll()
        {
            string sql = "Select Codigocliente, Nomefantasia FROM Clientes ORDER BY Nomefantasia";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Clientes> list = new List<Clientes>();
                Clientes p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Clientes();
                            p.CodigoCliente = (int)reader["Codigocliente"];
                            p.NomeFantasia = reader["Nomefantasia"].ToString();
                          
                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        ///<summary>Obtém uma pessoa pelo ID
        ///<param name="id">Id do registro que obtido.</param>
        ///<returns>Retorna uma referência de Clientes do registro encontrado ou null se ele não for encontrado.</returns>
        ///</summary>
        public override Clientes GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Codigocliente, Nomefantasia FROM Clientes WHERE Codigocliente=@Codigocliente";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigocliente", id);
                Clientes p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Clientes();
                                p.CodigoCliente = (int)reader["Codigocliente"];
                                p.NomeFantasia = reader["Nomefantasia"].ToString();
                               
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        ///<summary>Salva a pessoa no banco
        ///<param name="entity">Referência de Clientes que será salva.</param>
        ///</summary>
        public override void Save(Clientes entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Clientes (Nomefantasia) VALUES (@Nomefantasia)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nomefantasia", entity.NomeFantasia);               
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Atualiza a pessoa no banco
        ///<param name="entity">Referência de Clientes que será atualizada.</param>
        ///</summary>
        public override void Update(Clientes entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Clientes SET Nomefantasia=@Nomefantasia Where Codigocliente=@Codigocliente";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigocliente", entity.CodigoCliente);
                cmd.Parameters.AddWithValue("@Nomefantasia", entity.NomeFantasia);
               
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}