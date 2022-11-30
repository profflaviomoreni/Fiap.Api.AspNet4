using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioModel usuarioModel)
        {
            if ( usuarioModel.Senha.Equals("123456") )
            {
                usuarioModel.NomeUsuario = "Flavio";
                usuarioModel.Regra = "Junior";
                usuarioModel.Senha = "";

                var tokenUser = AuthenticationService.GetToken(usuarioModel);

                var retorno = new
                {
                    usuario = usuarioModel,
                    token = tokenUser
                };


                return Ok(retorno);

            } 
            else
            {
                return NotFound();
            }


            
        }


    }
}
