using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Application.Dtos.Requests
{
    public record CreateUserDto
    (
         string FullName,
         string Email,
         string Password
    );

}
