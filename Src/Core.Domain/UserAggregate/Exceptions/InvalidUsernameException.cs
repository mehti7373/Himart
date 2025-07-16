using System.Runtime.Serialization;
using Framework.Domain.Exceptions;

namespace Core.Domain.UserAggregate.Exceptions;

[Serializable]
public class InvalidUsernameException : FrameworkArgumentException<InvalidUsernameException>
{
    public InvalidUsernameException() : base("InvalidUsername") { }

    protected InvalidUsernameException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
