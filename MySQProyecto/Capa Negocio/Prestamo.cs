using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MySQProyecto.Capa_Negocio
{
    public class Prestamo
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Actualizar(string codAutor, string codLibro, string FechaPrestamo)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(string codAutor, string codLibro, string FechaPrestamo)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar(string texto, string criterio)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string ccodAutor)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string ccodAutor, string codLibro)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            string consulta = "select *from TPrestamo";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}