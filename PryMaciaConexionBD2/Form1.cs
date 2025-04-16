using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryMaciaConexionBD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            clsConexionBd objConexionBD = new clsConexionBd();

            clsConexionBd conexion = new clsConexionBd();
            conexion.ConectarBD();

            conexion.MostrarBD(dgvDatos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int telefono = 0;
            string correo = txtCorreo.Text;
            string categoria = txtCategoria.Text;

            clsConexionBd objConexionBD = new clsConexionBd();

            bool resultado = objConexionBD.AgregarPersona(nombre, apellido, telefono, correo, categoria);

            if (resultado)
            {
                MessageBox.Show("Persona agregada correctamente.");
                dgvDatos.DataSource = objConexionBD.MostrarBD(dgvDatos);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["nombre"].Value);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    int telefono = Convert.ToInt32(txtCorreo.Text);
                    string correo = txtCorreo.Text;
                    string categoria = txtCategoria.Text;

                    clsConexionBd objConexionBD = new clsConexionBd();
                    bool resultado = objConexionBD.EditarPersona( nombre, apellido, telefono, correo, categoria);

                    if (resultado)
                    {
                        MessageBox.Show("Contacto actualizado correctamente.");
                        dgvDatos.DataSource = objConexionBD.MostrarBD(dgvDatos);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un contacto para actualizar.");
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtCategoria.Text = fila.Cells["Categoria"].Value.ToString();
            }
    }
    }
}


