using System.Runtime.Serialization;

namespace Framework.Domain.Exceptions;

[Serializable]
public class FrameworkException : Exception
{
    public int Code { get; private set; }

    public FrameworkException(string? message = null, int code = 0)
        : base(message)
    {
        Code = code;
    }

    public FrameworkException(string? message, int? code, Exception? exception)
        : base(message, exception)
    {
        Code = code.GetValueOrDefault();
    }

    protected FrameworkException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}

[Serializable]
public class FrameworkException<TException> : FrameworkException where TException : FrameworkException<TException>, new()
{
    public FrameworkException(string? message = null, int code = 0)
        : base(message, code)
    {
    }

    protected FrameworkException(string? message, int? code, Exception? exception)
        : base(message, code, exception)
    {
    }

    protected FrameworkException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    public static TException Create(params object[] param)
    {
        return (Activator.CreateInstance(typeof(TException), param) as TException) ?? new TException();
    }
}