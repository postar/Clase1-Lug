using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Clase1_Lug
{
    public class Acceso
    {
        private SqlConnection conexion;
        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source =.\sqlexpress; Initial Catalog = LUG; Integrated Security = SSIP";
            conexion.Open();
        }
        public void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }
        public void Escribir (string sql)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
            }
        }
        public SqlDataReader Leer(string sql)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            return comando.ExecuteReader();
        }
    }
}