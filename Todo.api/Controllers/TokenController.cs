using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Dtos.Requests;
using Todo.Application.interfaces;

namespace Todo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController(ITokenService tokenService ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Get(TokenRequestDto request)
        {
           var result =  await tokenService.GetTokenAsync(request);
            return Ok(result);
        }
        
    }
}
