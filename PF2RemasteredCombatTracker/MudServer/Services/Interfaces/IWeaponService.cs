using MudServer.Models;

namespace MudServer.Services.Interfaces;

public interface IWeaponService
{
    Task<List<Weapon>> GetWeaponsAsync();
    Task<Weapon?> GetWeaponAsync(int id);
    Task SaveWeaponsAsync(List<Weapon> weapons);
    Task AddWeaponAsync(Weapon weapon);
    Task UpdateWeaponAsync(Weapon weapon);
}
