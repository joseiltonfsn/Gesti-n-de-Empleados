﻿using pjGestionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
    public class D_Empleados
    {
        public DataTable Listar_Empleados(string cBusqueda)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_EMPLEADOS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@cBusqueda", SqlDbType.VarChar).Value = cBusqueda;
                SqlCon.Open();

                resultado = comando.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if(SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string Guardar_Empleado(E_Empleado Empleado)
        {
            string respuesta = " ";
            SqlConnection sqlCon = new SqlConnection(); try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_GUARDAR_EMPLEADOS", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = Empleado.Nombre_Empleado;
                comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = Empleado.Direccion_Empleado;
                comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;
                comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = Empleado.Telefono_Empleado;
                comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = Empleado.Salario_Empleado;
                comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = Empleado.ID_Departamento;
                comando.Parameters.Add("@nIdCargo", SqlDbType.Int).Value = Empleado.ID_Cargo;

                sqlCon.Open();
               
                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Los Datos No Se Pudieron Registrar";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }

        public string Actualizar_Empleado(E_Empleado Empleado)
        {
            string respuesta = " ";
            SqlConnection sqlCon = new SqlConnection(); try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_ACTUALIZAR_EMPLEADOS", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = Empleado.ID_Empleado;
                comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = Empleado.Nombre_Empleado;
                comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = Empleado.Direccion_Empleado;
                comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;
                comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = Empleado.Telefono_Empleado;
                comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = Empleado.Salario_Empleado;
                comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = Empleado.ID_Departamento;
                comando.Parameters.Add("@nIdCargo", SqlDbType.Int).Value = Empleado.ID_Cargo;

                sqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Los Datos No Se Pudieron Registrar";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }

        public string Desactivar_Empleado(int iCodigoEmpleado)
        {
            string respuesta = " ";
            SqlConnection sqlCon = new SqlConnection(); 
            
            try
            {
                sqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SP_DESACTIVAR_EMPLEADOS", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = iCodigoEmpleado;

                sqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "Los Datos No Se Pudieron Desactivar";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return respuesta;
        }
    }
}
