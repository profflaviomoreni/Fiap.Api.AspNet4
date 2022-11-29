using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public IList<ProdutoModel> FindAll()
        {
            return _context.Produtos.Include(c => c.Categoria)
                                    .Include(m => m.Marca)
                                    .AsNoTracking()
                                    .ToList();
        }

        public ProdutoModel FindById(int id)
        {
            return _context.Produtos.Include(c => c.Categoria)
                                    .Include(m => m.Marca)
                                    .FirstOrDefault(x => x.ProdutoId == id);

            
        }

        public int Insert(ProdutoModel produtoModel)
        {
            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Update(ProdutoModel produtoModel)
        {
            _context.Produtos.Update(produtoModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = new ProdutoModel()
            {
                ProdutoId = id
            };

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}
