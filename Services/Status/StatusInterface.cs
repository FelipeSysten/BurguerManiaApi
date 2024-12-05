using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Status
{
    public interface StatusInterface
    {

        Task<ResponseModel<List<StatusModel>>> ListarStatus();

        Task<ResponseModel<StatusModel>> BuscarStatusPorId(int idStatus);

        Task<ResponseModel<StatusModel>> BuscarStatusPorIdOrder(int idOrder);
    }
}
