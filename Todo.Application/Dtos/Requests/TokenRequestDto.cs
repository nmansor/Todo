using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Application.Dtos.Requests
{
    public record TokenRequestDto(string userName, string Password);
   
}
