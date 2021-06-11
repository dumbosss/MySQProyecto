using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQProyecto.Capa_Negocio
{
    interface IPrestamo
    {
        DataTable Listar();

        bool Agregar(string codAutor, string codLibro, string FechaPrestamo);
        bool Eliminar(string ccodAutor, string codLibro);
        bool Actualizar(string codAutor, string codLibro, string FechaPrestamo);

        DataTable Buscar(string texto, string criterio);
    }
}
