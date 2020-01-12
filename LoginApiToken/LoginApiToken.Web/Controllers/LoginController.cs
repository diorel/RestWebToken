using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginApiToken.Entitys;
using LoginApiToken.Business;
using Newtonsoft.Json;

namespace LoginApiToken.Web.Controllers
{
    public class LoginController : ApiController
    {

        [Route("Admin/validaLogin")]
        [HttpPost]
        public object Crearpago([FromBody] Cuenta value)
        {      
            EnviarCuentaBisiness send = new EnviarCuentaBisiness();

            object _Respuesta ;
 
            try
            {
                _Respuesta = send.EnviarDtos(value.Correo , value.password);

            }
            catch (Exception e)
            {

                throw new Exception("Error insesperado (Bussines) " + e);
            }



            return _Respuesta;
        }


    }
}
