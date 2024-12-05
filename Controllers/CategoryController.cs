using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Category;
using WebApiBurguerMania.Services.User;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryInterface _categoryInterface;
        public CategoryController(CategoryInterface categoryInterface)
        {

            _categoryInterface = categoryInterface;
        }


        [HttpGet("ListarCategorys")]

        public async Task<ActionResult<ResponseModel<List<CategoryModel>>>> ListarCategorys()

        {
            var categorys = await _categoryInterface.ListarCategorys();
            return Ok(categorys);
        }

        [HttpGet("BuscarCategoryPorId/{idCategory}")]

        public async Task<ActionResult<ResponseModel<CategoryModel>>> BusacarCategoryPorId(int idCategory)

        {
            var category = await _categoryInterface.BuscarCategoryPorId(idCategory);
            return Ok(category);
        }

        [HttpGet("BuscarCategoryPorIdProduct/{idProduct}")]
        public async Task<ActionResult<ResponseModel<ProductsModel>>> BuscarCategoryPorIdProduct(int idProduct)
        {
            var category = await _categoryInterface.BuscarCategoryPorIdProduct(idProduct);
            return Ok(category);
        }


    }
}
