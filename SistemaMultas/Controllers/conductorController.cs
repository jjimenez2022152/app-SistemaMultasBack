using System.Web.Http;
using api_InfraccionesOnline.Models.Conductor;
using static api_InfraccionesOnline.Models.Conductor.csEstructuraConductor;

namespace api_InfraccionesOnline.Controllers
{
    public class conductorController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarConductor")]
        public IHttpActionResult insertarConductor(requestConductor model)
        {
            return Ok(new csConductor().insertarConductor(
                model.id_conductor,
                model.nombre,
                model.dpi
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarConductor")]
        public IHttpActionResult actualizarConductor(requestConductor model)
        {
            return Ok(new csConductor().actualizarConductor(
                model.id_conductor,
                model.nombre,
                model.dpi
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarConductor")]
        public IHttpActionResult eliminarConductor(requestEliminarConductor model)
        {
            return Ok(new csConductor().eliminarConductor(model.id_conductor));
        }

        [HttpGet]
        [Route("rest/api/listarConductores")]
        public IHttpActionResult listarConductores()
        {
            return Ok(new csConductor().listarConductores());
        }

        [HttpGet]
        [Route("rest/api/listarConductoresXid")]
        public IHttpActionResult listarConductoresXid(int id_conductor)
        {
            return Ok(new csConductor().listarConductoresXid(id_conductor));
        }
    }
}