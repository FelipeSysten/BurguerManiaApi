using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBurguerMania.Models;
using WebApiBurguerMania.Services.User;

namespace WebApiBurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        public UserController(UserInterface userInterface)
        {

            _userInterface = userInterface;
        }


        [HttpGet("ListarUser")]

        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListarUser()

        {
            var users = await _userInterface.ListarUser();
            return Ok(users);
        }

        [HttpGet("BuscarUserPorId/{idUser}")]

        public async Task<ActionResult<ResponseModel<UserModel>>> BusacarUserPorId(int idUser)

        {
            var user = await _userInterface.BuscarUserPorId(idUser);
            return Ok(user);
        }

        [HttpGet("BuscarUserPorIdOrder/{idOrder}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarUserPorIdOrder(int idOrder)
        {
            var user = await _userInterface.BuscarUserPorIdOrder(idOrder);
            return Ok(user);
        }



    }

}
