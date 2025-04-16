using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryMaciaConexionBD2
{
    internal class clsConexionBd
    {
        //cadena de conexion
        string cadena = "Server=localhost\\SQLEXPRESS;Database=Ventas2;Trusted_Connection=True;";

        //conector
        SqlConnection conexion;

        //comando
        SqlCommand comando;

        public string nombreBaseDeDatos;


        public void ConectarBD()
        {
            try
            {
                conexion = new SqlConnection(cadena);

                nombreBaseDeDatos = conexion.Database;

                conexion.Open();

                MessageBox.Show("Conectado a la base de datos: '" + nombreBaseDeDatos + "'.", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception error)
            {
                MessageBox.Show("Ups... algo salió mal al intentar conectar con la base de datos. Por favor, revise su conexión e intente nuevamente.", "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public DataTable MostrarBD(DataGridView Grilla)
        {
            DataTable tabla = new DataTable(); // declarar afuera para poder devolverla también en caso de error

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Contactos";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    adaptador.Fill(tabla);
                    Grilla.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudieron cargar los productos correctamente. Revise su conexión o intente más tarde.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tabla;
        }
        public bool AgregarPersona(string Nombre, string Apellido, int Telefono, string correo, string categoria)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "INSERT INTO Contactos (Nombre, Apellido, Telefono, Correo, Categoria) VALUES (@nombre, @apellido, @telefono, @correo, @categoria)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", Nombre);
                    comando.Parameters.AddWithValue("@apellido",Apellido);
                    comando.Parameters.AddWithValue("@telefono", Telefono);
                    comando.Parameters.AddWithValue("@correo", correo);
                    comando.Parameters.AddWithValue("@categoria", categoria);

                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
                return false;
            }

        }
        public bool EditarPersona(string Nombre, string Apellido, int Telefono, string correo, string categoria)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "INSERT INTO Contactos (Nombre, Apellido, Telefono, Correo, Categoria) VALUES (@nombre, @apellido, @telefono, @correo, @categoria)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", Nombre);
                    comando.Parameters.AddWithValue("@apellido", Apellido);
                    comando.Parameters.AddWithValue("@telefono", Telefono);
                    comando.Parameters.AddWithValue("@correo", correo);
                    comando.Parameters.AddWithValue("@categoria", categoria);

                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
                return false;
            }
        }


    }
}
