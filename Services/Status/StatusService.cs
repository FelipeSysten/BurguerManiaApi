using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Status
{
    public class StatusService : StatusInterface
    {

        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<StatusModel>> BuscarStatusPorId(int idStatus)
        {
            ResponseModel<StatusModel> resposta = new ResponseModel<StatusModel>();

            try
            {
                var statu = await _context.Status.FirstOrDefaultAsync(statusBanco => statusBanco.Id == idStatus);

                if (statu == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = statu;
                resposta.Mensagem = "Satatus localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<StatusModel>> BuscarStatusPorIdOrder(int idOrder)
        {
            ResponseModel<StatusModel> resposta = new ResponseModel<StatusModel>();
            try
            {
                var order = await _context.Orders.Include(s => s.Status).FirstOrDefaultAsync(orderBanco => orderBanco.Id == idOrder);

                if (order == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                resposta.Dados = order.Status;
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

        public async Task<ResponseModel<List<StatusModel>>> ListarStatus()
        {

            ResponseModel<List<StatusModel>> resposta = new ResponseModel<List<StatusModel>>();
            try
            {
                var status = await _context.Status.ToListAsync();
                resposta.Dados = status;
                resposta.Mensagem = "Todos os status coletados!";
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