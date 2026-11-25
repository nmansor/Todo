using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.interfaces;
using Todo.Domain.DomainEntities;

namespace Todo.Application.services
{
    public class PasswordHasher : IPasswordHassher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
