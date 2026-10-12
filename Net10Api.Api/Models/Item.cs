namespace Net10Api.Api.Models;

public record Item(
    Guid Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime CreatedAtUtc
);

public record CreateItemDto(
    string Title,
    string Description
);
