using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// InvalidPasswordException.
    /// </summary>
    class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message) { }

        public InvalidPasswordException(string message, Exception inner) : base(message, inner) { }
    }
}
