namespace MudServer.Models;
public class TacticalCharacter
{
    public CharacterCodex OriginalCharacter { get; set; }
    public bool IsFoe { get; set; }
    public int Initiative { get; set; }
}

