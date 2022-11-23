using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Microsoft.AspNetCore.Http;
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
        public IList<MarcaModel> Get()
        {
            var listaMarcas = dataContext.Marcas.AsNoTracking().ToList<MarcaModel>();

            return listaMarcas;
        }


        [HttpGet]
        [Route("{id:int}")]
        public MarcaModel GetById(int id)
        {
            var marca = dataContext.Marcas.AsNoTracking().FirstOrDefault( m => m.MarcaId == id );

            return marca;
        }


        [HttpPost]
        public MarcaModel Post(MarcaModel marcaModel)
        {
            dataContext.Marcas.Add(marcaModel);
            dataContext.SaveChanges();
            return marcaModel;
        }

        [HttpPut]
        [Route("{id:int}")]
        public MarcaModel Put(int id, MarcaModel marcaModel)
        {
            dataContext.Marcas.Update(marcaModel);
            dataContext.SaveChanges();
            return marcaModel;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            var marcaModel = new MarcaModel();
            marcaModel.MarcaId = id;

            dataContext.Marcas.Remove(marcaModel);
            dataContext.SaveChanges();
        }

    }
}
