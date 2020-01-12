using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LoginApiToken.Data;
using Microsoft.IdentityModel.Tokens;
using LoginApiToken.Entitys;


namespace LoginApiToken.Data
{
    public class ValidarDatosBd
    {

       public object validarDatos( string correo, string  password)
        {
            bool respuesta = false;
            Respuesta res = new  Respuesta();

            string Correo = "raul@hotmail.com";
            string Password = "nero32";
            string llaveSecreta = "IERUIEIRUIEKNEJRNEJJ323";

            if (Correo == correo)
            {
                if (Password == password)
                {
                    respuesta = true;

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, Correo),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                     };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(llaveSecreta));
                    var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    var expiracion = DateTime.UtcNow.AddHours(1);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "tudominio.com",
                    audience: "tudominio.com",
                    claims: claims,
                    expires: expiracion,
                    signingCredentials: creds);

                    res.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    res.Expiracion = expiracion.ToString();

                }
              
            }

            return res;
         
        }

    }
}
