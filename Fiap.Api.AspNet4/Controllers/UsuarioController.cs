using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Fiap.Api.AspNet4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository; 
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] UsuarioModel usuarioModel)
        {

            var usuario = usuarioRepository.FindByNameAndSenha(usuarioModel.NomeUsuario, usuarioModel.Senha);

            if (usuario != null)
            {
                usuarioModel.Senha = "";
                var tokenUser = AuthenticationService.GetToken(usuario);

                var retorno = new
                {
                    usuario = usuario,
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
