using MudServer.Models;

namespace MudServer.Services.Interfaces
{
    public interface ICharacterCodexService
    {
        Task<List<CharacterCodex>> GetAllAsync();
        Task<CharacterCodex?> GetAsync(int id);
        Task SaveAsync(List<CharacterCodex> characterCodex);
        Task AddAsync(CharacterCodex characterCodex);
        Task UpdateAsync(CharacterCodex characterCodex);
    }
}
