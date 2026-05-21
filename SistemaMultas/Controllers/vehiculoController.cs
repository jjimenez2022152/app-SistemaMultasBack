using api_InfraccionesOnline.Models.Vehiculo;
using System.Data;
using System.Web.Http;
using static api_InfraccionesOnline.Models.Vehiculo.csEstructuraVehiculo;

namespace api_InfraccionesOnline.Controllers
{
    public class vehiculoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarVehiculo")]
        public IHttpActionResult insertarVehiculo(requestVehiculo model)
        {
            return Ok(new csVehiculo().insertarVehiculo(
                model.id_vehiculo,
                model.placa,
                model.marca,
                model.id_conductor
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarVehiculo")]
        public IHttpActionResult actualizarVehiculo(requestVehiculo model)
        {
            return Ok(new csVehiculo().actualizarVehiculo(
                model.id_vehiculo,
                model.placa,
                model.marca,
                model.id_conductor
            ));
        }

        [HttpGet]
        [Route("rest/api/solvenciaVehicular")]
        public IHttpActionResult solvenciaVehicular(int id_vehiculo)
        {
            return Ok(new csVehiculo().solvenciaVehicular(id_vehiculo));
        }

        [HttpPost]
        [Route("rest/api/eliminarVehiculo")]
        public IHttpActionResult eliminarVehiculo(requestEliminarVehiculo model)
        {
            return Ok(new csVehiculo().eliminarVehiculo(model.id_vehiculo));
        }

        [HttpGet]
        [Route("rest/api/listarVehiculos")]
        public IHttpActionResult listarVehiculos()
        {
            return Ok(new csVehiculo().listarVehiculos());
        }

        [HttpGet]
        [Route("rest/api/listarVehiculosXid")]
        public IHttpActionResult listarVehiculosXid(int id_vehiculo)
        {
            return Ok(new csVehiculo().listarVehiculosXid(id_vehiculo));
        }
    }
}