using System.Web.Http;
using api_InfraccionesOnline.Models.Agente;
using static api_InfraccionesOnline.Models.Agente.csEstructuraAgente;

namespace api_InfraccionesOnline.Controllers
{
    public class agenteController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarAgente")]
        public IHttpActionResult insertarAgente(requestAgente model)
        {
            return Ok(new csAgente().insertarAgente(
                model.id_agente,
                model.nombre
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarAgente")]
        public IHttpActionResult actualizarAgente(requestAgente model)
        {
            return Ok(new csAgente().actualizarAgente(
                model.id_agente,
                model.nombre
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarAgente")]
        public IHttpActionResult eliminarAgente(requestEliminarAgente model)
        {
            return Ok(new csAgente().eliminarAgente(model.id_agente));
        }

        [HttpGet]
        [Route("rest/api/listarAgentes")]
        public IHttpActionResult listarAgentes()
        {
            return Ok(new csAgente().listarAgentes());
        }

        [HttpGet]
        [Route("rest/api/listarAgentesXid")]
        public IHttpActionResult listarAgentesXid(int id_agente)
        {
            return Ok(new csAgente().listarAgentesXid(id_agente));
        }
    }
}