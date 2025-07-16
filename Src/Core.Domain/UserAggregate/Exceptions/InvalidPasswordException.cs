using System.Runtime.Serialization;
using Framework.Domain.Exceptions;

namespace Core.Domain.UserAggregate.Exceptions;

[Serializable]
public class InvalidPasswordException : FrameworkArgumentException<InvalidPasswordException>
{
    public InvalidPasswordException() : base("InvalidPassword") { }

    protected InvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
