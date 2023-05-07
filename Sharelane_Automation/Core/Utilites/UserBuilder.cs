using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Core.Utilites
{
    public static class UserBuilder
    {
        public static User StandartUser => new User
        {
            Name = TestContext.Parameters.Get("UserName"),
            Password = TestContext.Parameters.Get("UserPassword"),
        };
    }
}
