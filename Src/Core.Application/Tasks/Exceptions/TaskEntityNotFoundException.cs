using System.Runtime.Serialization;
using Framework.Domain.Exceptions;

namespace Core.Application.Tasks.Exceptions;

[Serializable]
public class TaskEntityNotFoundException : FrameworkArgumentException<TaskEntityNotFoundException>
{
    public TaskEntityNotFoundException() : base("TaskEntityNotFound") { }

    protected TaskEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
