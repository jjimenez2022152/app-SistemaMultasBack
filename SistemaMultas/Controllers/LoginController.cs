using System.Web.Http;
using SistemaMultas.Models.Login;
using static SistemaMultas.Models.Login.csEstructuraLogin;

namespace SistemaMultas.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("rest/api/loginUsuario")]
        public responseLogin loginUsuario(requestLogin model)
        {
            csLogin login = new csLogin();

            return login.loginUsuario(
                model.username,
                model.password
            );
        }
    }
}