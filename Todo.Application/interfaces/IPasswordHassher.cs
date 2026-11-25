using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.Dtos.Requests;

namespace Todo.Application.interfaces
{
    public  interface  IPasswordHassher
    {

        public string Hash(string password);
        public bool Verify(string password, string passwordHash);
    }
}
