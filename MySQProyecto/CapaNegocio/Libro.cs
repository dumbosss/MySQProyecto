using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MySQProyecto.CapaNegocio
{
    public class Libro : ILibro
    {
        public bool Actualizar(string codLibro, string titulo, string editorial, int anio)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(string codLibro, string titulo, string editorial, int anio)
        {
            throw new NotImplementedException();
        }

        public DataTable Buscar(string texto, string criterio)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string codLibro)
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }
    }
}