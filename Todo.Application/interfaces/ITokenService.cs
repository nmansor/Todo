using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.Dtos.Requests;
using Todo.Application.Dtos.Responses;

namespace Todo.Application.interfaces
{
    public interface ITokenService
    {
        public Task<TokenResponseDto> GetTokenAsync(TokenRequestDto  request);
    }
}
