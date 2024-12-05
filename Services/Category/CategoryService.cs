using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Category
{
    public class CategoryService : CategoryInterface
    {

        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CategoryModel>> BuscarCategoryPorIdProduct(int idProduct)
        {
            ResponseModel<CategoryModel> resposta = new ResponseModel<CategoryModel>();
            try
            {
                var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(productBanco => productBanco.Id == idProduct);

                if (product == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                resposta.Dados = product.Category;
                resposta.Mensagem = "Produto encontrado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoryModel>> BuscarCategoryPorId(int idCategory)
        {
            ResponseModel<CategoryModel> resposta = new ResponseModel<CategoryModel>();

            try
            {
                var category = await _context.Category.FirstOrDefaultAsync(categoryBanco => categoryBanco.Id == idCategory);

                if (category == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = category;
                resposta.Mensagem = "Categoria localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CategoryModel>>> ListarCategorys()
        {
            ResponseModel<List<CategoryModel>> resposta = new ResponseModel<List<CategoryModel>>();
            try
            {
                var categorys = await _context.Category.ToListAsync();
                resposta.Dados = categorys;
                resposta.Mensagem = "Todos as categorias coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
