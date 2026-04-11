using System;

namespace api_InfraccionesOnline.Models.Conductor
{
    public class csEstructuraConductor
    {
        public class requestConductor
        {
            public int id_conductor { get; set; }
            public string nombre { get; set; }
            public string dpi { get; set; }
        }

        public class responseConductor
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarConductor
        {
            public int id_conductor { get; set; }
        }
    }
}