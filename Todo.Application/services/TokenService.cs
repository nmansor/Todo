using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Todo.Application.Dtos.Requests;
using Todo.Application.Dtos.Responses;
using Todo.Application.interfaces;
using Todo.Domain.DomainEntities;
using Todo.Domain.RepositoryInterface;

namespace Todo.Application.services
{
    public class TokenService(IUserRepository repo, IConfiguration configuration, IPasswordHassher hasher) : ITokenService
    {
        public async Task<TokenResponseDto> GetTokenAsync(TokenRequestDto request)
        {

            var userDomain = await repo.GetByEmailAsync(request.userName);
            if (userDomain == null )
            {
               // throw new InvalidEmailException(ErrorConstants.BadEmail);
            }

            var isPasswordValid = hasher.Verify(request.Password, userDomain.PasswordHash);
             if(!isPasswordValid)
            {
                // throw new InvalidEmailException(ErrorConstants.BadPassword);
            }

            var token = GenerateToken(userDomain);

            return new TokenResponseDto(token, string.Empty);
        }

       

        private string GenerateToken(UserDomain userResponse)
        {
            var secretKey = configuration["Jwt:Secret"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var crudentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                     Subject = new ClaimsIdentity([
                               new Claim(ClaimTypes.Name, userResponse.FullName),
                               new Claim(ClaimTypes.Email, userResponse.Email),
                               new Claim("UserId", userResponse.Id.ToString())
                         ]
                    ),
                    Expires = DateTime.UtcNow.AddMinutes( Convert.ToInt32(configuration["Jwt:TokenExpiryInMinutes"])),
                    SigningCredentials = crudentails,
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"],
                };

            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }

        
    }
}
