using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjGestionEmpleados.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        //constructor de la clase
        private Conexion()
        {
            this.Servidor = "JOSEFS\\SQLEXPRESS";
            this.Base = "bd_gestion_empleados";
            this.Usuario = "sa";
            this.Clave = "0923";
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                           "; Database=" + this.Base +
                                           "; User Id=" + this.Usuario +
                                           "; Password=" + this.Clave;

                //"Server=JOSEFS\\SQLEXPRESS;Database=bd_gestion_empleados;User Id=sa;Password=0923"
            }
            catch (Exception ex) 
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion crearInstancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
