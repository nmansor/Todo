using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.interfaces;

namespace Todo.Application.services
{
    public class CurrentUserService : ICurrentUserSerice
    {
        public string GetCurrentUserId(IHttpContextAccessor httpAccessor)
        {
            var userId = httpAccessor.HttpContext.Request.Headers["CurrentUserId"];
            if (!string.IsNullOrWhiteSpace(userId))
            {
                return userId;
            }
                
            return  string.Empty;
        }
    }
}
