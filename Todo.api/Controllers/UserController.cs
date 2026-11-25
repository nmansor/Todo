using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Dtos.Requests;
using Todo.Application.interfaces;

namespace Todo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto request)
        {
           var result =  await service.AddAsync(request);
            return Created(); //201
        }
    }
}
