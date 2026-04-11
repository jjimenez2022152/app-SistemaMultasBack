using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.EstadoInfraccion
{
    public class csEstadoInfraccion
    {
        public class responseEstadoInfraccion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseEstadoInfraccion insertarEstadoInfraccion(int id_estado, string descripcion)
        {
            responseEstadoInfraccion result = new responseEstadoInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO EstadoInfraccion(id_estado, descripcion) VALUES ("
                    + id_estado + ", '"
                    + descripcion + "')";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Estado de infracción registrado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseEstadoInfraccion actualizarEstadoInfraccion(int id_estado, string descripcion)
        {
            responseEstadoInfraccion result = new responseEstadoInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE EstadoInfraccion SET descripcion = '" + descripcion +
                                "' WHERE id_estado = " + id_estado;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Estado de infracción actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseEstadoInfraccion eliminarEstadoInfraccion(int id_estado)
        {
            responseEstadoInfraccion result = new responseEstadoInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM EstadoInfraccion WHERE id_estado = " + id_estado;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Estado de infracción eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarEstadosInfraccion()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM EstadoInfraccion";
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";

                return dsi;
            }
            catch
            {
                return null;
            }
        }

        public DataSet listarEstadosInfraccionXid(int id_estado)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM EstadoInfraccion WHERE id_estado = " + id_estado;
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsi);
                dsi.Tables[0].TableName = "lista";

                return dsi;
            }
            catch
            {
                return null;
            }
        }
    }
}