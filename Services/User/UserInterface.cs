using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.User
{
    public interface UserInterface
    {
        Task<ResponseModel<List<UserModel>>> ListarUser();

        Task<ResponseModel<UserModel>> BuscarUserPorId(int idUser);

        Task<ResponseModel<UserModel>> BuscarUserPorIdOrder (int idOrder);
    }
}
