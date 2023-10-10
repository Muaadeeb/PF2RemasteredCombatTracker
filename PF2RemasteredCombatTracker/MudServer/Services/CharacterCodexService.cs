using MudServer.Models;
using MudServer.Services.Interfaces;
using System.Text.Json;

namespace MudServer.Services;

public class CharacterCodexService : ICharacterCodexService
{
    private const string JsonFileName = "Data/characterCodex.json";

    public async Task<List<CharacterCodex>> GetAllAsync()
    {
        using var fileStream = new FileStream(JsonFileName, FileMode.Open);
        var results = await JsonSerializer.DeserializeAsync<List<CharacterCodex>>(fileStream);
        return results ?? new List<CharacterCodex>();
    }

    public async Task<CharacterCodex?> GetAsync(int id)
    {
        var results = await GetAllAsync();
        return results.FirstOrDefault(w => w.Id == id);
    }

    public async Task SaveAsync(List<CharacterCodex> weapons)
    {
        using var fileStream = new FileStream(JsonFileName, FileMode.Create);
        await JsonSerializer.SerializeAsync(fileStream, weapons);
    }

    public async Task AddAsync(CharacterCodex characterCodex)
    {
        try
        {
            var results = await GetAllAsync();
            characterCodex.Id = results.Count + 1;
            results.Add(characterCodex);
            await SaveAsync(results);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateAsync(CharacterCodex updatedCharacterCodex)
    {
        var results = await GetAllAsync();
        var characterCodex = results.Find(w => w.Id == updatedCharacterCodex.Id);

        if (characterCodex != null)
        {
            characterCodex.CreatureName = updatedCharacterCodex.CreatureName;
            characterCodex.HP = updatedCharacterCodex.HP;
            characterCodex.AC = updatedCharacterCodex.AC;
            characterCodex.AttackBonusMelee = updatedCharacterCodex.AttackBonusMelee;
            characterCodex.AttackBonusRanged = updatedCharacterCodex.AttackBonusRanged;
            characterCodex.Weapons = updatedCharacterCodex.Weapons;

            await SaveAsync(results);
        }
    }
}
