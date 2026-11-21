using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Exceptions
{
    public class InvalidUserNameOrPassword : Exception
    {
        public InvalidUserNameOrPassword() : base("Invalid UserName Or Password")
        {

        }
    }
}
