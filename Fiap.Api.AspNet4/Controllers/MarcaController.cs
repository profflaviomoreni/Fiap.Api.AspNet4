using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {

        private readonly IMarcaRepository marcaRepository;

        public MarcaController(IMarcaRepository _marcaRepository)
        {
            marcaRepository = _marcaRepository;
        }


        /*
        [HttpGet]
        public ActionResult<IList<MarcaModel>> Get()
        {
            var listaMarcas = dataContext.Marcas.AsNoTracking().ToList<MarcaModel>();

            if ( listaMarcas == null || listaMarcas.Count == 0  )
            {
                return NoContent();
            } else
            {
                return Ok(listaMarcas);
            }
            
        }
        */


        [HttpGet]
        public async Task<ActionResult<IList<dynamic>>> Get(
                [FromQuery] int pagina = 0,
                [FromQuery] int tamanho = 3
            )
        {
            var totalGeral = marcaRepository.Count();
            var totalPagina = Convert.ToInt16( Math.Ceiling((double) totalGeral/tamanho ) );
            var anterior = pagina > 0 ? $"marca?pagina={pagina - 1}&tamanho={tamanho}" : "";
            var proxima = pagina < totalPagina -1 ? $"marca?pagina={pagina + 1}&tamanho={tamanho}" : "";

            if ( pagina > totalPagina )
            {
                return NotFound();
            }

            var marcas = marcaRepository.FindAll(pagina, tamanho);

            var retorno = new
            {
                total = totalGeral,
                totalPaginas = totalPagina,
                anterior = anterior,
                proxima = proxima,
                marcas = marcas
            };

            return Ok(retorno);

        }




        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<MarcaModel> GetById([FromRoute] int id)
        {
            var marca = marcaRepository.FindById(id);

            if ( marca == null ) {
                return NotFound();
            }

            return Ok(marca);
        }


        [HttpPost]
        public ActionResult<MarcaModel> Post([FromBody] MarcaModel marcaModel)
        {
            try { 

                if ( ! ModelState.IsValid  )
                {
                    return BadRequest(ModelState);
                }

                marcaModel.MarcaId = marcaRepository.Insert(marcaModel);

                var location = new Uri(Request.GetEncodedUrl() + marcaModel.MarcaId);

                return Created(location,marcaModel);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<MarcaModel> Put([FromRoute] int id, [FromBody] MarcaModel marcaModel)
        {
            try
            {
                if( ( id == 0 ) || ( id != marcaModel.MarcaId))
                {
                    return BadRequest(new { message = $"Não foi possível alterar a marca {id}" });
                }


                if ( ! ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }


                marcaRepository.Update(marcaModel);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<MarcaModel> Delete([FromRoute] int id)
        {

            var marcaModel = marcaRepository.FindById(id);
            
            if ( marcaModel == null )
            {
                return NotFound();
            }


            marcaRepository.Delete(id);
            return NoContent();
        }

    }
}
