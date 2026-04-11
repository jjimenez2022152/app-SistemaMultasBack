using System.Web.Http;
using api_InfraccionesOnline.Models.Sancion;
using static api_InfraccionesOnline.Models.Sancion.csEstructuraSancion;

namespace api_InfraccionesOnline.Controllers
{
    public class sancionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarSancion")]
        public IHttpActionResult insertarSancion(requestSancion model)
        {
            return Ok(new csSancion().insertarSancion(
                model.id_sancion,
                model.descripcion,
                model.monto
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarSancion")]
        public IHttpActionResult actualizarSancion(requestSancion model)
        {
            return Ok(new csSancion().actualizarSancion(
                model.id_sancion,
                model.descripcion,
                model.monto
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarSancion")]
        public IHttpActionResult eliminarSancion(requestEliminarSancion model)
        {
            return Ok(new csSancion().eliminarSancion(model.id_sancion));
        }

        [HttpGet]
        [Route("rest/api/listarSanciones")]
        public IHttpActionResult listarSanciones()
        {
            return Ok(new csSancion().listarSanciones());
        }

        [HttpGet]
        [Route("rest/api/listarSancionesXid")]
        public IHttpActionResult listarSancionesXid(int id_sancion)
        {
            return Ok(new csSancion().listarSancionesXid(id_sancion));
        }
    }
}