using Core.Domain.PersonAggregate.Exceptions;
using Core.Domain.PersonAggregate.Validator;
using Framework.Domain.Exceptions;
using Framework.Domain.Models;

namespace Core.Domain.PersonAggregate.ValueObjects;

public record NationalCode : BaseValueObject
{
    private NationalCode()
    {

    }
    public NationalCode(string value)
    {

        if (NationalCodeValidator.IsValid(value) is false)
        {
            throw InvalidNationalCodeException.Create();
        }
    }
    public string Value { get; private set; }
}
