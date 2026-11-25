using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Todo.Infrastructure.Persistence.Entities;

namespace Todo.api.MiddleWare
{
    public class CurrentUserContext
    {
        private readonly  RequestDelegate _next;
        public CurrentUserContext(RequestDelegate  next) {
           _next = next;
        }

        public async Task EnvokeAsync(HttpContext context)
        {
            var token = await context.GetTokenAsync("Access_Token");

            if (string.IsNullOrWhiteSpace(token))
            {
                await _next(context);    // depends on the requirement but for now do not short circut pipe line and just continue
            }
            else
            {
                var userId = GetUserId(token);
                context.Request.Headers.Add("CurrentUser_Id", userId.ToString());
            }

            await _next(context);
        }

        private Guid GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken =  handler.ReadJwtToken(token);
            var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")!.Value;

            return Guid.Parse(userId);
        }
    }
}
