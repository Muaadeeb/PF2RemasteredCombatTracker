using MudServer.Common.Enums;

namespace MudServer.Models;

public class CharacterCodex
{
    public int Id { get; set; }
    public string CreatureName { get; set; }
    public HealthStatus CurrentHealthStatus { get; set; } = HealthStatus.Healthy;
    public int HP { get; set; }
    public int HPCurrent { get; set; }
    public int AC { get; set; }
    public List<Weapon> Weapons { get; set; }
    public int AttackBonusMelee { get; set; }
    public int AttackBonusRanged { get; set; }
    public int BonusDamageMelee { get; set; }
    public int BonusDamageRanged { get; set; }

    public CharacterCodex(string creatureName, List<Weapon> weapons)
    {
        CreatureName = creatureName;
        Weapons = weapons;
    }
}
