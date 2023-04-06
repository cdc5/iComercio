using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Exceptions
{
    public class ErrorException:Exception
    {
         public ErrorException()
        : base() { }
    
        public ErrorException(string message)
        : base(message) { }
    
        public ErrorException(string format, params object[] args)
        : base(string.Format(format, args)) { }
    
        public ErrorException(string message, Exception innerException)
        : base(message, innerException) { }

        public ErrorException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
