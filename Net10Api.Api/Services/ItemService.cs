using System;
using System.Collections.Concurrent;
using Net10Api.Api.Models;

namespace Net10Api.Api.Services;

public class ItemService : IItemService
{
    private readonly ConcurrentDictionary<Guid, Item> _items = new();

    public ItemService()
    {
        var seed = new Item(Guid.NewGuid(), "Migrar a .NET 10", "Completar la migración de la API al nuevo SDK de .NET 10", false, DateTime.UtcNow);
        _items.TryAdd(seed.Id, seed);
    }

    public Task<IEnumerable<Item>> GetAllAsync() => Task.FromResult(_items.Values.AsEnumerable());

    public Task<Item?> GetByIdAsync(Guid id)
    {
        _items.TryGetValue(id, out var item);
        return Task.FromResult(item);
    }

    public Task<Item> CreateAsync(CreateItemDto dto)
    {
        var item = new Item(Guid.NewGuid(), dto.Title, dto.Description, false, DateTime.UtcNow);
        _items.TryAdd(item.Id, item);
        return Task.FromResult(item);
    }
}
