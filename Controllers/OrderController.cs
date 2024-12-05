using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Oder;
using WebApiBurguerMania.Services.User;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderInterface _orderInterface;
        public OrderController(OrderInterface orderInterface)
        {

            _orderInterface = orderInterface;
        }

        [HttpGet("ListarOrder")]

        public async Task<ActionResult<ResponseModel<List<OrderModel>>>> ListarOrder()

        {
            var orders = await _orderInterface.ListarOrder();
            return Ok(orders);
        }

        [HttpGet("BuscarOrderPorId/{idOrder}")]

        public async Task<ActionResult<ResponseModel<OrderModel>>> BusacarOrderPorId(int idOrder)

        {
            var order = await _orderInterface.BuscarOrderPorId(idOrder);
            return Ok(order);
        }

        [HttpGet("BuscarOrderPorIdProduct/{idProduct}")]
        public async Task<ActionResult<ResponseModel<OrderModel>>> BuscarOrderPorIdProduct(int idProduct)
        {
            var order = await _orderInterface.BuscarOrderPorIdProduct(idProduct);
            return Ok(order);
        }


    }
}
