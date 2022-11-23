using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Get";
        }

        [HttpPost]
        public string Post() // INSERT
        {
            return "Post";
        }


        [HttpPut]
        public string Put() // UPDATE
        {
            return "Put";
        }


        [HttpDelete]
        public string Delete()  // DELETE
        {
            return "Delete";
        }


    }
}
