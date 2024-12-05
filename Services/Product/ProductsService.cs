using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Product
{
    public class ProductsService : ProductsInterface
    {

        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<ProductsModel>> BuscarProductPorId(int idProduct)
        {
            ResponseModel<ProductsModel> resposta = new ResponseModel<ProductsModel>();

            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(productBanco => productBanco.Id == idProduct);

                if (product == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = product;
                resposta.Mensagem = "Usuario localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProductsModel>> BuscarProductsPorIdOrder(int idOrder)
        {
            ResponseModel<ProductsModel> resposta = new ResponseModel<ProductsModel>();
            try
            {
                var order = await _context.Orders.Include(p => p.Products).FirstOrDefaultAsync(orderBanco => orderBanco.Id == idOrder);

                if (order == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                resposta.Dados = (ProductsModel)order.Products;
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

        public async Task<ResponseModel<List<ProductsModel>>> ListarProducts()
        {
            ResponseModel<List<ProductsModel>> resposta = new ResponseModel<List<ProductsModel>>();
            try
            {
                var products = await _context.Products.ToListAsync();
                resposta.Dados = products;
                resposta.Mensagem = "Todos os usuarios coletados!";
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
