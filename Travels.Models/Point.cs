using System;

namespace Travels.Models;

public record Point
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string Country { get; init; }
    public bool IsDeleted { get; init; } = false;

    public string ShortId => Id.ToString()[..8];
}
