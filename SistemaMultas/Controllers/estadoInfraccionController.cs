using System.Web.Http;
using api_InfraccionesOnline.Models.EstadoInfraccion;
using static api_InfraccionesOnline.Models.EstadoInfraccion.csEstructuraEstadoInfraccion;

namespace api_InfraccionesOnline.Controllers
{
    public class estadoInfraccionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarEstadoInfraccion")]
        public IHttpActionResult insertarEstadoInfraccion(requestEstadoInfraccion model)
        {
            return Ok(new csEstadoInfraccion().insertarEstadoInfraccion(
                model.id_estado,
                model.descripcion
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarEstadoInfraccion")]
        public IHttpActionResult actualizarEstadoInfraccion(requestEstadoInfraccion model)
        {
            return Ok(new csEstadoInfraccion().actualizarEstadoInfraccion(
                model.id_estado,
                model.descripcion
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarEstadoInfraccion")]
        public IHttpActionResult eliminarEstadoInfraccion(requestEliminarEstadoInfraccion model)
        {
            return Ok(new csEstadoInfraccion().eliminarEstadoInfraccion(model.id_estado));
        }

        [HttpGet]
        [Route("rest/api/listarEstadosInfraccion")]
        public IHttpActionResult listarEstadosInfraccion()
        {
            return Ok(new csEstadoInfraccion().listarEstadosInfraccion());
        }

        [HttpGet]
        [Route("rest/api/listarEstadosInfraccionXid")]
        public IHttpActionResult listarEstadosInfraccionXid(int id_estado)
        {
            return Ok(new csEstadoInfraccion().listarEstadosInfraccionXid(id_estado));
        }
    }
}