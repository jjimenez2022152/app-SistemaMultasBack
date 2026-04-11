using System.Web.Http;
using api_InfraccionesOnline.Models.Infraccion;
using static api_InfraccionesOnline.Models.Infraccion.csEstructuraInfraccion;

namespace api_InfraccionesOnline.Controllers
{
    public class infraccionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarInfraccion")]
        public IHttpActionResult insertarInfraccion(requestInfraccion model)
        {
            return Ok(new csInfraccion().insertarInfraccion(
                model.id_infraccion,
                model.fecha,
                model.lugar,
                model.id_vehiculo,
                model.id_agente,
                model.id_sancion,
                model.id_estado
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarInfraccion")]
        public IHttpActionResult actualizarInfraccion(requestInfraccion model)
        {
            return Ok(new csInfraccion().actualizarInfraccion(
                model.id_infraccion,
                model.fecha,
                model.lugar,
                model.id_vehiculo,
                model.id_agente,
                model.id_sancion,
                model.id_estado
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarInfraccion")]
        public IHttpActionResult eliminarInfraccion(requestEliminarInfraccion model)
        {
            return Ok(new csInfraccion().eliminarInfraccion(model.id_infraccion));
        }

        [HttpGet]
        [Route("rest/api/listarInfracciones")]
        public IHttpActionResult listarInfracciones()
        {
            return Ok(new csInfraccion().listarInfracciones());
        }

        [HttpGet]
        [Route("rest/api/listarInfraccionesXid")]
        public IHttpActionResult listarInfraccionesXid(int id_infraccion)
        {
            return Ok(new csInfraccion().listarInfraccionesXid(id_infraccion));
        }
    }
}