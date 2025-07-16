using System.Runtime.Serialization;
using Framework.Domain.Exceptions;

namespace Core.Domain.UserAggregate.Exceptions;

[Serializable]
public class InvalidEmailException : FrameworkArgumentException<InvalidUsernameException>
{
    public InvalidEmailException() : base("InvalidUsername") { }

    protected InvalidEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
