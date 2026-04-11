using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.Pago
{
    public class csPago
    {
        public class responsePago
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responsePago insertarPago(int id_pago, DateTime fecha_pago, decimal monto, int id_infraccion)
        {
            responsePago result = new responsePago();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO Pagos(id_pago, fecha_pago, monto, id_infraccion) VALUES ("
                    + id_pago + ", '"
                    + fecha_pago.ToString("yyyy-MM-dd HH:mm:ss") + "', "
                    + monto + ", "
                    + id_infraccion + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Pago registrado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responsePago actualizarPago(int id_pago, DateTime fecha_pago, decimal monto, int id_infraccion)
        {
            responsePago result = new responsePago();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE Pagos SET fecha_pago = '" + fecha_pago.ToString("yyyy-MM-dd HH:mm:ss") +
                                "', monto = " + monto +
                                ", id_infraccion = " + id_infraccion +
                                " WHERE id_pago = " + id_pago;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Pago actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responsePago eliminarPago(int id_pago)
        {
            responsePago result = new responsePago();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM Pagos WHERE id_pago = " + id_pago;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Pago eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarPagos()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Pagos";
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

        public DataSet listarPagosXid(int id_pago)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Pagos WHERE id_pago = " + id_pago;
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