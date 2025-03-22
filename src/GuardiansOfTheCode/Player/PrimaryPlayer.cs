using Common;
using GuardiansOfTheCode.Strategies;

namespace GuardiansOfTheCode.Player;

public sealed class PrimaryPlayer(IAnsiConsole console)
{
    public string Name { get; set; } = "Player 1";
    public int Level { get; set; } = 1;
    public int Health { get; set; } = 100;
    public int Armor { get; set; } = 10;
    public IWeapon Weapon { get; set; } = new Sword(10, 5);
    public IEnumerable<Card> Cards { get; set; } = [];

    public IDamageIndicator DamageIndicator =>
        Health < 30 ? new CriticalHealthIndicator(console, Name) : new RegularDamageIndicator(console, Name);
}
