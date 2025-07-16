using Core.Domain.Shared.ValueObjects;
using Core.Domain.TaskAggregate.ValueObjects;

namespace Core.Domain.TaskAggregate.DomainService;
internal interface ITaskDomainService
{
    bool IsValidCheckoutDate(CreateAt createAt, CheckOutDate? checkOutDate);
}
internal class TaskDomainService : ITaskDomainService
{
    bool ITaskDomainService.IsValidCheckoutDate(CreateAt createAt, CheckOutDate? checkOutDate)=>
          checkOutDate is null ||
          createAt.Value >= (checkOutDate!.Value).ToDateTime(TimeOnly.MinValue);
    
}
