using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.Infraccion
{
    public class csInfraccion
    {
        public class responseInfraccion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseInfraccion insertarInfraccion(int id_infraccion, DateTime fecha, string lugar, int id_vehiculo, int id_agente, int id_sancion, int id_estado)
        {
            responseInfraccion result = new responseInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO Infracciones(id_infraccion, fecha, lugar, id_vehiculo, id_agente, id_sancion, id_estado) VALUES ("
                    + id_infraccion + ", '"
                    + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + lugar + "', "
                    + id_vehiculo + ", "
                    + id_agente + ", "
                    + id_sancion + ", "
                    + id_estado + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Infracción registrada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseInfraccion actualizarInfraccion(int id_infraccion, DateTime fecha, string lugar, int id_vehiculo, int id_agente, int id_sancion, int id_estado)
        {
            responseInfraccion result = new responseInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE Infracciones SET fecha = '" + fecha.ToString("yyyy-MM-dd HH:mm:ss") +
                    "', lugar = '" + lugar +
                    "', id_vehiculo = " + id_vehiculo +
                    ", id_agente = " + id_agente +
                    ", id_sancion = " + id_sancion +
                    ", id_estado = " + id_estado +
                    " WHERE id_infraccion = " + id_infraccion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Infracción actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseInfraccion eliminarInfraccion(int id_infraccion)
        {
            responseInfraccion result = new responseInfraccion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM Infracciones WHERE id_infraccion = " + id_infraccion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Infracción eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarInfracciones()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Infracciones";
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

        public DataSet listarInfraccionesXid(int id_infraccion)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Infracciones WHERE id_infraccion = " + id_infraccion;
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