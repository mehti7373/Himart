using Core.Domain.UserAggregate.Exceptions;
using System.Runtime.Serialization;
using Framework.Domain.Exceptions;

namespace Core.Domain.PersonAggregate.Exceptions;

[Serializable]
public class InvalidNationalCodeException : FrameworkArgumentException<InvalidNationalCodeException>
{
    public InvalidNationalCodeException() : base("InvalidNationalCode") { }

    protected InvalidNationalCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
