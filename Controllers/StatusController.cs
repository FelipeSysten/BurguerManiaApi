using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.Status;
using WebApiBurguerMania.Services.User;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly StatusInterface _statusInterface;
        public StatusController(StatusInterface statusInterface)
        {

            _statusInterface = statusInterface;
        }

        [HttpGet("ListarStatus")]

        public async Task<ActionResult<ResponseModel<List<StatusModel>>>> ListarStatus()

        {
            var status = await _statusInterface.ListarStatus();
            return Ok(status);
        }

        [HttpGet("BuscarStatusPorId")]

        public async Task<ActionResult<ResponseModel<StatusModel>>> BusacarStatusPorId(int idStatus)

        {
            var user = await _statusInterface.BuscarStatusPorId(idStatus);
            return Ok(user);
        }

        [HttpGet("BuscarStatusPorIdOrder/{idOrder}")]
        public async Task<ActionResult<ResponseModel<StatusModel>>> BuscarUtatusPorIdOrder(int idOrder)
        {
            var status = await _statusInterface.BuscarStatusPorIdOrder(idOrder);
            return Ok(status);
        }
    }
}
