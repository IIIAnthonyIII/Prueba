using APITienda.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APITienda.Controllers
{
  [ApiController]
  public class UserController : ControllerBase
  {
    public IConfiguration _configuration;
    public UserController(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    [HttpPost]
    [Route("usuarios")]
    public dynamic Login ([FromBody] Object optData)
    {
      var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
      string transaccion = data.transaccion.ToString();
      if (string.IsNullOrEmpty(transaccion) || transaccion != "autenticarUsuario")
      {
        return new
        {
          codigoRetorno = false,
          mensajeRetorno = "Ingrese transaccion correcta",
          usuario = "",
          token = ""
        };
      }
      string user = data.datosUsuario.email.ToString();
      string password = data.datosUsuario.password.ToString();
      UserModel userModel = UserModel.UserDB().Where(d => d.email==user && d.password==password).FirstOrDefault();
      if (userModel == null)
      {
        return new
        {
          codigoRetorno = false,
          mensajeRetorno = "Usuario no encontrado o contraseña incorrecta",
          usuario = "",
          token = ""
        };
      }
      var jwt = _configuration.GetSection("Jwt").Get<JWTModel>();
      var clains = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        new Claim("email",userModel.email),
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
      var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
          jwt.Issuer,
          jwt.Audience,
          clains,
          expires: DateTime.Now.AddMinutes(5),
          signingCredentials: singIn
        );
      return new
      {
        codigoRetorno = 0001,
        mensajeRetorno = "consulta correcta",
        usuario = new 
        {
          email = userModel.email,
          nombre = userModel.nombre,
          plan = userModel.plan,
          telefono = userModel.telefono
        },
        token = new JwtSecurityTokenHandler().WriteToken(token)
      };
    }
  }
}
