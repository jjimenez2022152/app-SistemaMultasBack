using System;

namespace api_InfraccionesOnline.Models.Sancion
{
    public class csEstructuraSancion
    {
        public class requestSancion
        {
            public int id_sancion { get; set; }
            public string descripcion { get; set; }
            public decimal monto { get; set; }
        }

        public class responseSancion
        {
            public int respuesta { get; set; }
            public string descripcion_respuesta { get; set; }
        }

        public class requestEliminarSancion
        {
            public int id_sancion { get; set; }
        }
    }
}