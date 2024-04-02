using Application.Domain.Core.User.Models;

namespace Application.Domain.Core.User.Models;

public readonly record struct UserId(long Value) : ISnowflakeId
{
    public long Value { get;} = Value;
}