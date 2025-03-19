using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemies;

public class Werewolf(IAnsiConsole console, int health, int level, int armor = 0) : IEnemy
{
    private readonly int _originalHealth = health;
    private readonly int _originalArmor = armor;
    public int Level { get; } = level;
    public int Health { get; set; } = health;
    public int Armor { get; set; } = armor;
    public int OvertimeDamage { get; set; }
    public bool Paralyzed { get; set; }
    public int ParalyzedFor { get; set; }

    public void Attack(PrimaryPlayer player)
    {
        console.MarkupLineInterpolated($"Werewolf attacks Player {player.Name}!");
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
