using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaMultas.Models.Login
{
    public class csLogin
    {
        public csEstructuraLogin.responseLogin loginUsuario(string username, string password)
        {
            csEstructuraLogin.responseLogin result =
                new csEstructuraLogin.responseLogin();

            string conexion = "";
            SqlConnection con = null;

            try
            {
                conexion = ConfigurationManager
                    .ConnectionStrings["cnConnection"]
                    .ConnectionString;

                con = new SqlConnection(conexion);

                con.Open();

                string cadena =
                    "SELECT * FROM Usuarios " +
                    "WHERE username = '" + username + "' " +
                    "AND password = '" + password + "'";

                SqlCommand cmd = new SqlCommand(cadena, con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result.respuesta = 1;
                    result.descripcion_respuesta = "Login correcto";
                }
                else
                {
                    result.respuesta = 0;
                    result.descripcion_respuesta = "Usuario o contraseña incorrectos";
                }
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = ex.Message;
            }

            if (con != null)
                con.Close();

            return result;
        }
    }
}