using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace Todo.Application.interfaces
{
    public interface ICurrentUserSerice
    {
      
        public string GetCurrentUserId(IHttpContextAccessor  httpAccessor);
        
    }
}
