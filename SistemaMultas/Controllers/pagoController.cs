using System.Web.Http;
using api_InfraccionesOnline.Models.Pago;
using static api_InfraccionesOnline.Models.Pago.csEstructuraPago;

namespace api_InfraccionesOnline.Controllers
{
    public class pagoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarPago")]
        public IHttpActionResult insertarPago(requestPago model)
        {
            return Ok(new csPago().insertarPago(
                model.id_pago,
                model.fecha_pago,
                model.monto,
                model.id_infraccion
            ));
        }

        [HttpPost]
        [Route("rest/api/actualizarPago")]
        public IHttpActionResult actualizarPago(requestPago model)
        {
            return Ok(new csPago().actualizarPago(
                model.id_pago,
                model.fecha_pago,
                model.monto,
                model.id_infraccion
            ));
        }

        [HttpPost]
        [Route("rest/api/eliminarPago")]
        public IHttpActionResult eliminarPago(requestEliminarPago model)
        {
            return Ok(new csPago().eliminarPago(model.id_pago));
        }

        [HttpGet]
        [Route("rest/api/listarPagos")]
        public IHttpActionResult listarPagos()
        {
            return Ok(new csPago().listarPagos());
        }

        [HttpGet]
        [Route("rest/api/listarPagosXid")]
        public IHttpActionResult listarPagosXid(int id_pago)
        {
            return Ok(new csPago().listarPagosXid(id_pago));
        }
    }
}