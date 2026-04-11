using System;

namespace api_InfraccionesOnline.Models.Vehiculo
{
    public class csEstructuraVehiculo
    {
        public class requestVehiculo
        {
            public int id_vehiculo { get; set; }
            public string placa { get; set; }
            public string marca { get; set; }
            public int id_conductor { get; set; }
        }

        public class responseVehiculo
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarVehiculo
        {
            public int id_vehiculo { get; set; }
        }
    }
}