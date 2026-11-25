using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Application.Dtos.Responses
{
    public record class TokenResponseDto(string token, string v);
   
}
