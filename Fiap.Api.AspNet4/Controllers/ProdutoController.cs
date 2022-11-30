using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet4.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IList<ProdutoModel>> Get(
            [FromServices] IProdutoRepository produtoRepository)
        {
            var produto = produtoRepository.FindAll();

            if (produto.Count == 0)
            {
                return NoContent();
            }

            return Ok(produto);
        }


        [HttpGet("{id:int}")]
        public ActionResult<ProdutoModel> GetById(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            var produto = produtoRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoModel> Post(
            [FromServices] IProdutoRepository produtoRepository,
            [FromBody] ProdutoModel produtoModel)
        {
            

            try
            {
                var categoriaId = produtoRepository.Insert(produtoModel);
                produtoModel.ProdutoId = categoriaId;

                var location = new Uri(Request.GetEncodedUrl() + categoriaId);

                return Created(location, produtoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o produto. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProdutoModel> Put(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository,
            [FromBody] ProdutoModel produtoModel)
        {


            if (produtoModel.ProdutoId != id)
            {
                return NotFound();
            }

            try
            {
                produtoRepository.Update(produtoModel);

                return Ok(produtoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o produto. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<ProdutoModel> Delete(
            [FromRoute] int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            produtoRepository.Delete(id);

            return Ok();
        }
    }
}
