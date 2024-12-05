using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Oder
{
    public interface OrderInterface
    {

        Task<ResponseModel<List<OrderModel>>> ListarOrder();

        Task<ResponseModel<OrderModel>> BuscarOrderPorId(int idOrder);

        Task<ResponseModel<OrderModel>> BuscarOrderPorIdProduct(int idProduct);
    }
}
