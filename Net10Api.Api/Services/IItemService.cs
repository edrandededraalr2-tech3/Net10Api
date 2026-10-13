using System.Collections.Generic;
using System.Threading.Tasks;
using Net10Api.Api.Models;

namespace Net10Api.Api.Services;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(Guid id);
    Task<Item> CreateAsync(CreateItemDto dto);
}
