using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.Sancion
{
    public class csSancion
    {
        public class responseSancion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseSancion insertarSancion(int id_sancion, string descripcion, decimal monto)
        {
            responseSancion result = new responseSancion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO Sanciones(id_sancion, descripcion, monto) VALUES ("
                    + id_sancion + ", '"
                    + descripcion + "', "
                    + monto + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Sanción registrada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseSancion actualizarSancion(int id_sancion, string descripcion, decimal monto)
        {
            responseSancion result = new responseSancion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE Sanciones SET descripcion = '" + descripcion +
                                "', monto = " + monto +
                                " WHERE id_sancion = " + id_sancion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Sanción actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseSancion eliminarSancion(int id_sancion)
        {
            responseSancion result = new responseSancion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM Sanciones WHERE id_sancion = " + id_sancion;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Sanción eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarSanciones()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Sanciones";
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

        public DataSet listarSancionesXid(int id_sancion)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Sanciones WHERE id_sancion = " + id_sancion;
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