using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemies;

public class Werewolf(IAnsiConsole console, int health, int level, int armor = 0) : IEnemy
{
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
}
