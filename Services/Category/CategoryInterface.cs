using WebApiBurguerMania.Models;

namespace WebApiBurguerMania.Services.Category
{
    public interface CategoryInterface
    {
        Task<ResponseModel<List<CategoryModel>>> ListarCategorys();

        Task<ResponseModel<CategoryModel>> BuscarCategoryPorId(int idCategory);

        Task<ResponseModel<CategoryModel>> BuscarCategoryPorIdProduct(int idProduct);
    }
}
