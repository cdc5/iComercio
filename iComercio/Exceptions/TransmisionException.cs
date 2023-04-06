using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*using System.Runtime.Serialization;

[Serializable]*/
namespace iComercio.Exceptions
{
    public class TransmisionException:Exception
    {
        public TransmisionException()
        : base() { }
    
        public TransmisionException(string message)
        : base(message) { }
    
        public TransmisionException(string format, params object[] args)
        : base(string.Format(format, args)) { }
    
        public TransmisionException(string message, Exception innerException)
        : base(message, innerException) { }
    
        public TransmisionException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    
        /*protected TransmisionException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }*/
    }
}
