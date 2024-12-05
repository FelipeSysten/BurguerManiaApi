using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Product;
using WebApiBurguerMania.Services.User;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsInterface _productsInterface;
        public ProductController(ProductsInterface productsInterface)
        {

            _productsInterface = productsInterface;
        }


        [HttpGet("ListarProducts")]

        public async Task<ActionResult<ResponseModel<List<ProductsModel>>>> ListarProducts()

        {
            var products = await _productsInterface.ListarProducts();
            return Ok(products);
        }

        [HttpGet("BuscarProductPorId/{idProduct}")]

        public async Task<ActionResult<ResponseModel<ProductsModel>>> BusacarProductPorId(int idProduct)

        {
            var product = await _productsInterface.BuscarProductPorId(idProduct);
            return Ok(product);
        }

        [HttpGet("BuscarProductPorIdOrder/{idOrder}")]
        public async Task<ActionResult<ResponseModel<ProductsModel>>> BuscarProductPorIdOrder(int idOrder)
        {
            var product = await _productsInterface.BuscarProductsPorIdOrder(idOrder);
            return Ok(product);
        }


    }
}
