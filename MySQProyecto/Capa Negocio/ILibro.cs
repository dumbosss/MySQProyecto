using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQProyecto.Capa_Negocio
{
    interface ILibro
    {
        DataTable Listar();

        bool Agregar(string codLibro, string titulo, string editorial);
        bool Eliminar(string codLibro);
        bool Actualizar(string codLibro, string titulo, string editorial);

        DataTable Buscar(string texto, string criterio);
    }
}
