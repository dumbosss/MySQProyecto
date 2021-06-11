using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using MySQProyecto.Capa_Negocio;

namespace MySQProyecto
{
    public partial class Default : System.Web.UI.Page
    {
        private Capa_Negocio.Autor autor = new Capa_Negocio.Autor();
        //cadena de conexion de web config
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

        private void Listar()
        {
            string consulta = "select *from tautor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            gvAutor.DataSource = tabla;
            gvAutor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //leer los datos 
                string codAutor = txtCodautor.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string nombres = txtNombres.Text.Trim();
                string nacionalidad = txtNacionalidad.Text.Trim();
                string consulta = "insert into tautor values(@codautor,@apellidos,@nombres,@nacionalidad)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                //envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                //ejecutar el insert
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    Response.Write("No se agrego");
            }
            catch (Exception ex)
            {

                Response.Write("Error" + ex.Message);
            }
            
        }

        protected void btnEliminarr_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "delete from tautor where codautor ='"+txtCodautor.Text.Trim()+"'";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    Response.Write("error al eliminar");
            }
            catch (Exception ex)
            {

                conexion.Close();
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnListar_Click()
        {
            string consulta = "select *from tautor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            gvAutor.DataSource = tabla;
            gvAutor.DataBind();
        }


        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            string busq = txtbuscarA.Text.Trim();
            Autor autor = new Autor();
            gvAutor.DataSource = autor.Buscar(busq);
            gvAutor.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string codAutor = txtCodautor.Text.Trim();
            string Apellidos = txtApellidos.Text.Trim();
            string Nombres = txtNombres.Text.Trim();
            string Nacionalidad = txtNacionalidad.Text.Trim();

            if (autor.Actualizar(codAutor, Apellidos, Nombres, Nacionalidad))
                Listar();
            else
                Response.Write("No se agrego");

            Listar();

        }
    }
}
            