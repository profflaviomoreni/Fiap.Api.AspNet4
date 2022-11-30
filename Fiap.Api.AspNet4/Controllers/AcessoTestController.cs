using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcessoTestController : ControllerBase
    {

        [HttpGet]
        [Route("Anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anonimo";
        }

        [HttpGet]
        [Route("Autenticado")]
        public string Autenticado()
        {
            return "Autenticado";
        }

        [HttpGet]
        [Route("Junior")]
        [Authorize(Roles = "Junior, Pleno, Senior")]
        public string Junior()
        {
            return "Junior";
        }

        [HttpGet]
        [Route("Pleno")]
        [Authorize(Roles = "Pleno, Senior")]
        public string Pleno()
        {
            return "Pleno";
        }

        [HttpGet]
        [Route("Senior")]
        [Authorize(Roles = "Senior")]
        public string Senior()
        {
            return "Pleno";
        }

    }
}
