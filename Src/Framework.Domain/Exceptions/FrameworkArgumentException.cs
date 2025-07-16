using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Framework.Domain.Exceptions;

[Serializable]
public class FrameworkArgumentException<TException> : FrameworkException<TException> where TException : FrameworkArgumentException<TException>, new()
{
    public FrameworkArgumentException(string? message = null, int code = 0)
        : base(message, code)
    {
    }

    protected FrameworkArgumentException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
