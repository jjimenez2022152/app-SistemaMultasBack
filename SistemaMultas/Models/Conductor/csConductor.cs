using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.Conductor
{
    public class csConductor
    {
        public class responseConductor
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseConductor insertarConductor(int id_conductor, string nombre, string dpi)
        {
            responseConductor result = new responseConductor();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO Conductores(id_conductor, nombre, dpi) VALUES ("
                    + id_conductor + ", '"
                    + nombre + "', '"
                    + dpi + "')";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Conductor registrado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseConductor actualizarConductor(int id_conductor, string nombre, string dpi)
        {
            responseConductor result = new responseConductor();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE Conductores SET nombre = '" + nombre +
                                "', dpi = '" + dpi +
                                "' WHERE id_conductor = " + id_conductor;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Conductor actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseConductor eliminarConductor(int id_conductor)
        {
            responseConductor result = new responseConductor();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM Conductores WHERE id_conductor = " + id_conductor;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Conductor eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarConductores()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Conductores";
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

        public DataSet listarConductoresXid(int id_conductor)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Conductores WHERE id_conductor = " + id_conductor;
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