using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Oder
{
    public class OrderService : OrderInterface
    {

        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<OrderModel>> BuscarOrderPorId(int idOrder)
        {
            ResponseModel<OrderModel> resposta = new ResponseModel<OrderModel>();

            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(orderBanco => orderBanco.Id == idOrder);

                if (order == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = order;
                resposta.Mensagem = "Pedido localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<OrderModel>> BuscarOrderPorIdProduct(int idProduct)
        {
            ResponseModel<OrderModel> resposta = new ResponseModel<OrderModel>();
            try
            {
                var product = await _context.Products.Include(o => o.Order).FirstOrDefaultAsync(productBanco => productBanco.Id == idProduct);

                if (product == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                resposta.Dados = product.Order;
                resposta.Mensagem = "Pedido encontrado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<OrderModel>>> ListarOrder()
        {
            ResponseModel<List<OrderModel>> resposta = new ResponseModel<List<OrderModel>>();
            try
            {
                var orders = await _context.Orders.ToListAsync();
                resposta.Dados = orders;
                resposta.Mensagem = "Todos os pedidos coletados!";
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
