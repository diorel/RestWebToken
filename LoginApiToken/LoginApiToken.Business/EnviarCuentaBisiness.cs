using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApiToken.Data;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;



namespace LoginApiToken.Business
{
    public class EnviarCuentaBisiness
    {

        public object EnviarDtos(string correo, string password)
        {
            ValidarDatosBd sendData = new ValidarDatosBd();

            var respuesta = sendData.validarDatos(correo, password);

            return respuesta;
        }


    }
}
