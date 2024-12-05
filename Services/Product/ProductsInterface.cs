using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Product
{
    public interface ProductsInterface
    {
        Task<ResponseModel<List<ProductsModel>>> ListarProducts();

        Task<ResponseModel<ProductsModel>> BuscarProductPorId(int idProduct);

        Task<ResponseModel<ProductsModel>> BuscarProductsPorIdOrder(int idOrder);
    }
}
