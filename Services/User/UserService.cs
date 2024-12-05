using Microsoft.EntityFrameworkCore;
using WebApiBurguerMania.Data;
using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.User
{
    public class UserService : UserInterface
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<UserModel>> BuscarUserPorId(int idUser)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();

            try
            {
                var user = await _context.User.FirstOrDefaultAsync(userBanco => userBanco.Id == idUser);

                if (user == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = user;
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

        public async Task<ResponseModel<UserModel>> BuscarUserPorIdOrder(int idOrder)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var order = await _context.Orders.Include(u => u.User).FirstOrDefaultAsync(orderBanco => orderBanco.Id == idOrder);
           
                if(order == null)
                {
                    resposta.Mensagem = "Nenhum registro Localizado!";
                    return resposta;
                }

                resposta.Dados = order.User;
                resposta.Mensagem = "Usuario encontrado!";
                return resposta;
            
            
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }




        }

        public async Task<ResponseModel<List<UserModel>>> ListarUser()
        {

            ResponseModel<List<UserModel>> resposta = new ResponseModel<List<UserModel>>();
            try
            {
                var users = await _context.User.ToListAsync();
                resposta.Dados = users;
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
