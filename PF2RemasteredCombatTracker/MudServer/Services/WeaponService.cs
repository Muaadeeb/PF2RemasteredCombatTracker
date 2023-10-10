using MudServer.Models;
using MudServer.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class WeaponService : IWeaponService
{
    private const string JsonFileName = "Data/weapons.json";

    public async Task<List<Weapon>> GetWeaponsAsync()
    {
        using var fileStream = new FileStream(JsonFileName, FileMode.Open);
        var weapons = await JsonSerializer.DeserializeAsync<List<Weapon>>(fileStream);
        return weapons ?? new List<Weapon>();
    }

    public async Task<Weapon?> GetWeaponAsync(int id)
    {
        var weapons = await GetWeaponsAsync();
        return weapons.FirstOrDefault(w => w.Id == id);
    }

    public async Task SaveWeaponsAsync(List<Weapon> weapons)
    {
        using var fileStream = new FileStream(JsonFileName, FileMode.Create);
        await JsonSerializer.SerializeAsync(fileStream, weapons);
    }

    public async Task AddWeaponAsync(Weapon weapon)
    {
        try
        {
            var weapons = await GetWeaponsAsync();
            // Assign an ID to the new weapon (could be more sophisticated, but for simplicity, we'll use this)
            weapon.Id = weapons.Count + 1;
            weapons.Add(weapon);
            await SaveWeaponsAsync(weapons);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateWeaponAsync(Weapon updatedWeapon)
    {
        var weapons = await GetWeaponsAsync();
        var weapon = weapons.Find(w => w.Id == updatedWeapon.Id);

        if (weapon != null)
        {
            weapon.Name = updatedWeapon.Name;
            weapon.DamageDie = updatedWeapon.DamageDie;
            weapon.DamageDieCount = updatedWeapon.DamageDieCount;
            weapon.DamageBonus = updatedWeapon.DamageBonus;
            await SaveWeaponsAsync(weapons);
        }
    }
}
