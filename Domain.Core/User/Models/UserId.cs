using Domain.Core.User.Models;

namespace Domain.Core.User.Models;

public readonly record struct UserId(long value) : ISnowflakeId
{
    public long Value { get; } = value;
}