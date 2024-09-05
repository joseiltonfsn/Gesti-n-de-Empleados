﻿using pjGestionEmpleados.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmConectar : Form
    {
        public frmConectar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SqlCon = new SqlConnection();
            SqlCon = Conexion.crearInstancia().CrearConexion();

            try
            {
                SqlCon.Open();
                MessageBox.Show("Conexion Exitosa");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Conexion Fallida");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
