using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryMaciaConexionBD2
{
    internal class clsDatos
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string correo { get; set; }
        public string Categoria { get; set; }
         
        public clsDatos(string Nombre, string Apellido, int Telefono, string correo, string categoria) 
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.correo = correo;
            this.Categoria = categoria;
            

        }
     
    }
}
