using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace api_InfraccionesOnline.Models.Vehiculo
{
    public class csVehiculo
    {
        public class responseVehiculo
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public responseVehiculo insertarVehiculo(int id_vehiculo, string placa, string marca, int id_conductor)
        {
            responseVehiculo result = new responseVehiculo();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "INSERT INTO Vehiculos(id_vehiculo, placa, marca, id_conductor) VALUES ("
                    + id_vehiculo + ", '"
                    + placa + "', '"
                    + marca + "', "
                    + id_conductor + ")";

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Vehículo registrado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseVehiculo actualizarVehiculo(int id_vehiculo, string placa, string marca, int id_conductor)
        {
            responseVehiculo result = new responseVehiculo();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "UPDATE Vehiculos SET placa = '" + placa +
                                "', marca = '" + marca +
                                "', id_conductor = " + id_conductor +
                                " WHERE id_vehiculo = " + id_vehiculo;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Vehículo actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public responseVehiculo eliminarVehiculo(int id_vehiculo)
        {
            responseVehiculo result = new responseVehiculo();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "DELETE FROM Vehiculos WHERE id_vehiculo = " + id_vehiculo;

                SqlCommand cmd = new SqlCommand(cadena, con);
                result.respuesta = cmd.ExecuteNonQuery();
                result.descripcion_respuesta = "Vehículo eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.respuesta = 0;
                result.descripcion_respuesta = "Error: " + ex.Message;
            }

            con.Close();
            return result;
        }

        public DataSet listarVehiculos()
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Vehiculos";
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

        public DataSet listarVehiculosXid(int id_vehiculo)
        {
            DataSet dsi = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = "SELECT * FROM Vehiculos WHERE id_vehiculo = " + id_vehiculo;
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

        public DataSet solvenciaVehicular(int id_vehiculo)
        {
            DataSet dsi = new DataSet();

            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(conexion);

            try
            {
                con.Open();

                string cadena = @"
        SELECT 
            v.placa,
            v.marca,
            c.nombre AS conductor,
            i.id_infraccion,
            i.fecha,
            s.descripcion AS sancion,
            s.monto,
            e.descripcion AS estado
        FROM Vehiculos v
        INNER JOIN Conductores c
            ON v.id_conductor = c.id_conductor
        INNER JOIN Infracciones i
            ON v.id_vehiculo = i.id_vehiculo
        INNER JOIN Sanciones s
            ON i.id_sancion = s.id_sancion
        INNER JOIN EstadoInfraccion e
            ON i.id_estado = e.id_estado
        WHERE v.id_vehiculo = " + id_vehiculo + @"
        AND e.descripcion = 'Pendiente'";

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
