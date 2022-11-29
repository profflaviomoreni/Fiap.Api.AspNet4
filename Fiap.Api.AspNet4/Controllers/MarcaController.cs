using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {

        private readonly DataContext dataContext;

        public MarcaController(DataContext ctx)
        {
            dataContext = ctx;
        }


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


        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<MarcaModel> GetById([FromRoute] int id)
        {
            var marca = dataContext.Marcas.AsNoTracking().FirstOrDefault( m => m.MarcaId == id );

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

                dataContext.Marcas.Add(marcaModel);
                dataContext.SaveChanges();

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


                dataContext.Marcas.Update(marcaModel);
                dataContext.SaveChanges();
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

            var marcaModel = dataContext.Marcas.AsNoTracking().FirstOrDefault( m => m.MarcaId == id );
            
            if ( marcaModel == null )
            {
                return NotFound();
            }


            dataContext.Marcas.Remove(marcaModel);
            dataContext.SaveChanges();
            return NoContent();
        }

    }
}
