using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Strategies;

namespace GuardiansOfTheCode.Enemies;

public class Werewolf(IAnsiConsole console, int health, int level, int armor = 0) : IEnemy
{
    private readonly int _originalHealth = health;
    private readonly int _originalArmor = armor;

    public string Name => "Werewolf";
    public int Level { get; } = level;
    public int Health { get; set; } = health;
    public int Armor { get; set; } = armor;
    public int OvertimeDamage { get; set; }
    public bool Paralyzed { get; set; }
    public int ParalyzedFor { get; set; }

    public IDamageIndicator DamageIndicator =>
        Health < 30 ? new CriticalHealthIndicator(console, Name) : new RegularDamageIndicator(console, Name);

    public int Attack(PrimaryPlayer player)
    {
        console.MarkupLineInterpolated($"Werewolf attacks Player {player.Name}!");
        return 20;
    }

    public void Defend(PrimaryPlayer player)
    {
        console.MarkupLineInterpolated($"WereWolf defends against Player {player.Name}!");
    }

    public void Reset()
    {
        Health = _originalHealth;
        Armor = _originalArmor;
        OvertimeDamage = 0;
        Paralyzed = false;
        ParalyzedFor = 0;
    }
}
