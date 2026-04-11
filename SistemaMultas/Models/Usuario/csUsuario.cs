using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using api_InfraccionesOnline.Models.Usuario;
using System.Data;

namespace api_InfraccionesOnline.Models.Usuario
{
    public class csUsuario
    {
        public class responseUsuario
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseUsuario insertarUsuario(int id_usuario, string username, string password, int id_agente)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "INSERT INTO Usuarios(id_usuario, username, password, id_agente) VALUES ("
                                + id_usuario + ", '"
                                + username + "', '"
                                + password + "', "
                                + id_agente + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Operación realizada exitosamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseUsuario actualizarUsuario(int id_usuario, string username, string password, int id_agente)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "UPDATE Usuarios SET username = '" + username +
                "', password = '" + password +
                "', id_agente = " + id_agente +
                " WHERE id_usuario = " + id_usuario;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Operación realizada exitosamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseUsuario eliminarUsuario(int id_usuario)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                con = new SqlConnection(conexion);
                con.Open();

                string cadena = "DELETE FROM Usuarios WHERE id_usuario = " + id_usuario;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Usuario eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarUsuarios()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "select * from usuarios";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet listarUsuariosXid(int id_usuario)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();

            try
            {
                string cadena = "select * from usuarios WHERE id_usuario= '" + id_usuario + "'";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";
                return dsi;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}