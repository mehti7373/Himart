using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.IServices.Models;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Application.IServices;

public interface IAuthService
{
    TokenModel GetToken(string userName, Guid userId, UserRole role);
}
