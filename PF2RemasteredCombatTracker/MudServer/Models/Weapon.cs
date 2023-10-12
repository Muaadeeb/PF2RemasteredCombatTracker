namespace MudServer.Models;
public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DamageDie { get; set; }
    public int DamageDieCount { get; set; }
    public int DamageBonus { get; set; }
    public bool IsMelee { get; set; }

    public Weapon(string name)
    {
        Name = name;
    }
}
