using api_InfraccionesOnline.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static api_InfraccionesOnline.Models.Usuario.csEstructuraUsuario;

namespace api_InfraccionesOnline.Controllers
{
    public class usuarioController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarUsuario")]
        public IHttpActionResult insertarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().insertarUsuario(
                model.id_usuario,
                model.username,
                model.password,
                model.id_agente
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarUsuario")]
        public IHttpActionResult actualizarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().actualizarUsuario(
                model.id_usuario,
                model.username,
                model.password,
                model.id_agente
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarUsuario")]
        public IHttpActionResult eliminarUsuario(requestEliminarUsuario model)
        {
            return Ok(new csUsuario().eliminarUsuario(model.id_usuario));
        }

        [HttpGet]
        [Route("rest/api/listarUsuarios")]
        public IHttpActionResult listarUsuarios()
        {
            return Ok(new csUsuario().listarUsuarios());
        }

        [HttpGet]
        [Route("rest/api/listarUsuariosXid")]
        public IHttpActionResult listarUsuariosXid(int id_usuario)
        {
            return Ok(new csUsuario().listarUsuariosXid(id_usuario));
        }
    }
}